using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Fofx
{
    public abstract class BaseRequestHelper : ITimeSeriesRequestHelper, IComparable<ITimeSeriesRequestHelper>
    {
        public BaseRequestHelper()
        {
        }

        public abstract ITimeSeries CreateNew(ITimeSeriesIterator itearator, TimeSeriesDescriptor factor);

        public abstract void Add(ITimeSeries iTimeSeries, INullableReader reader, DatabaseRequestArgs args, TimeSeriesDatabaseContext requester);

        public abstract INullableReader GetDataReader(int[] entites, int[] factors, DatabaseRequestArgs args);

        public virtual void Read(int[] entities, int[] timeseries, DatabaseRequestArgs args, TimeSeriesDatabaseContext requester, Dictionary<long, ITimeSeriesKey> keys, SortedList<ITimeSeriesKey, ITimeSeries> dbTimeSeriesResult)
        {
            ITimeSeries referenceTimeSeries = null;
            ITimeSeriesKey referenceKey = null;
            Dictionary<ITimeSeriesKey, ITimeSeries> newTimeSeriesList = new Dictionary<ITimeSeriesKey, ITimeSeries>(dbTimeSeriesResult);


            int previousEntityID = -1;
            int previousTimeSeriesValueID = -1;

            using (INullableReader reader = GetDataReader(entities, timeseries, args))
            {
                while (reader.Read())
                {
                    int entityID = reader.GetInt32(0);
                    int timeSeriesValueID = reader.GetInt32(1);

                    if (entityID != previousEntityID || previousTimeSeriesValueID != timeSeriesValueID)
                    {
                        referenceTimeSeries = null;
                        long key = ((long)entityID << 32) + timeSeriesValueID;
                        if (keys.TryGetValue(key, out referenceKey))
                            newTimeSeriesList.TryGetValue(referenceKey, out referenceTimeSeries);


                        previousEntityID = entityID;
                        previousTimeSeriesValueID = timeSeriesValueID;
                    }

                    if (referenceTimeSeries != null)
                        Add(referenceTimeSeries, reader, args, requester);
                }
            }
        }

        public virtual SortedList<ITimeSeriesKey, ITimeSeries> ReadTimeSeries(IEnumerable<TimeSeriesKey> dbCallRequired, DatabaseRequestArgs args, TimeSeriesDatabaseContext requester)
        {
            SortedList<ITimeSeriesKey, ITimeSeries> dbTimeSeriesResult = new SortedList<ITimeSeriesKey, ITimeSeries>();
            Dictionary<long, ITimeSeriesKey> keys = new Dictionary<long, ITimeSeriesKey>();

            SortedSet<int> dbEntityIDs = new SortedSet<int>();
            SortedSet<int> dbTimeSeriesValueDefinitionIDs = new SortedSet<int>();

            foreach (TimeSeriesKey key in dbCallRequired)
            {
                long pr = ((long)key.Entity.ID << 32) + key.TimeSeries.ValueDefinition;
                if (!keys.ContainsKey(pr))
                {
                    keys.Add(pr, key);
                    ITimeSeries series = CreateNew(args.Iterator, key.TimeSeries);
                    dbTimeSeriesResult.Add(key, series);
                }

                dbTimeSeriesValueDefinitionIDs.Add(key.TimeSeries.ValueDefinition);
                dbEntityIDs.Add(key.Entity.ID);
            }

            Read(dbEntityIDs.ToArray(), dbTimeSeriesValueDefinitionIDs.ToArray(), args, requester, keys, dbTimeSeriesResult);

            return dbTimeSeriesResult;
        }

        public virtual int CompareTo(object obj)
        {
            return CompareTo((ITimeSeriesRequestHelper)obj);
        }

        public virtual int CompareTo(ITimeSeriesRequestHelper helper)
        {
            return this.GetType().Name.CompareTo(helper.GetType().Name);
        }
    }

    public abstract class BaseRevisableRequestHelper : BaseRequestHelper, ITimeSeriesRequestHelper
    {
        public SqlParameter[] GetParameters(int[] entities, int[] factors, DatabaseRequestArgs args) => new SqlParameter[]
            {
                new SqlParameter("@EntityIDs", DataManipulation.ToCSVString(entities)),
                new SqlParameter("@TimeSeriesValueIDs", DataManipulation.ToCSVString(factors)),
                new SqlParameter("@IAAD", args.Iterator.Iaad),
                new SqlParameter("@StartDate", args.Iterator.StartDate),
                new SqlParameter("@StartOffset", args.Iterator.StartOffset),
                new SqlParameter("@EndDate", args.Iterator.EndDate),
                new SqlParameter("@EndOffset", args.Iterator.EndOffset)
            };
    }

    public abstract class BaseSnapshotRequestHelper : BaseRequestHelper, ITimeSeriesRequestHelper
    {
        public SqlParameter[] GetParameters(int[] entities, int[] factors, DatabaseRequestArgs args) => new SqlParameter[]
            {
                new SqlParameter("@EntityIDs", DataManipulation.ToCSVString(entities)),
                new SqlParameter("@TimeSeriesValueIDs", DataManipulation.ToCSVString(factors)),
                new SqlParameter("@IAAD", args.Iterator.Iaad),
                new SqlParameter("@StartDate", args.Iterator.StartDate),
                new SqlParameter("@EndDate", args.Iterator.EndDate)
            };
    }

    public abstract class BaseCharacteristicRequestHelper : BaseRequestHelper, ITimeSeriesRequestHelper
    {
        public SqlParameter[] GetParameters(int[] entities, int[] factors, DatabaseRequestArgs args)
        {
            SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@EntityIDs", DataManipulation.ToCSVString(entities)),
            new SqlParameter("@TimeSeriesValueID", DataManipulation.ToCSVString(factors))
                };

            return parameters;
        }
    }

    public abstract class BaseRelationshipRevisableRequestHelper : BaseRequestHelper, ITimeSeriesRequestHelper
    {
        protected struct QuickID : IEquatable<QuickID>
        {
            private int m_EntityID;
            private int m_TimeseriesValueID;
            private int m_RelationshipValueID;
            private int m_HashCode;

            public QuickID(int entity, int timeseries, int relationship)
            {
                m_EntityID = entity;
                m_TimeseriesValueID = timeseries;
                m_RelationshipValueID = relationship;

                unchecked
                {
                    m_HashCode = 17;
                    m_HashCode = m_HashCode * 31 + m_EntityID.GetHashCode();
                    m_HashCode = m_HashCode * 31 + m_TimeseriesValueID.GetHashCode();
                    m_HashCode = m_HashCode * 31 + m_RelationshipValueID.GetHashCode();
                }
            }

            public bool Equals(QuickID qi)
            {
                return m_EntityID == qi.m_EntityID && m_TimeseriesValueID == qi.m_TimeseriesValueID && m_RelationshipValueID == qi.m_RelationshipValueID;
            }

            public override bool Equals(object obj)
            {
                QuickID qi = (QuickID)obj;
                return m_EntityID == qi.m_EntityID && m_TimeseriesValueID == qi.m_TimeseriesValueID && m_RelationshipValueID == qi.m_RelationshipValueID;
            }

            public override int GetHashCode()
            {
                return m_HashCode;
            }
        }

        public abstract INullableReader GetDataReader(int[] entites, int[] factors, int[] relationships, DatabaseRequestArgs args);

        public override SortedList<ITimeSeriesKey, ITimeSeries> ReadTimeSeries(IEnumerable<TimeSeriesKey> dbCallRequired, DatabaseRequestArgs args, TimeSeriesDatabaseContext requester)
        {
            SortedList<ITimeSeriesKey, ITimeSeries> dbTimeSeriesResult = new SortedList<ITimeSeriesKey, ITimeSeries>();
            Dictionary<QuickID, ITimeSeriesKey> keys = new Dictionary<QuickID, ITimeSeriesKey>();


            SortedSet<int> dbEntityIDs = new SortedSet<int>();
            SortedSet<int> dbTimeSeriesValueDefinitionIDs = new SortedSet<int>();
            SortedSet<int> dbRelationshipValueDefinitionIDs = new SortedSet<int>();

            foreach (RelationshipTimeSeriesKey key in dbCallRequired)
            {
                QuickID qid = new QuickID(key.Entity.ID, key.TimeSeries.ValueDefinition, key.Relationship.ValueDefinition);

                if (!keys.ContainsKey(qid))
                {
                    ITimeSeries series = CreateNew(args.Iterator, key.TimeSeries);
                    keys.Add(qid, key);
                    dbTimeSeriesResult.Add(key, series);
                }

                dbTimeSeriesValueDefinitionIDs.Add(key.TimeSeries.ValueDefinition);
                dbEntityIDs.Add(key.Entity.ID);
                dbRelationshipValueDefinitionIDs.Add(((RelationshipTimeSeriesKey)key).Relationship.ValueDefinition);
            }

            Read(dbEntityIDs.ToArray(), dbTimeSeriesValueDefinitionIDs.ToArray(), dbRelationshipValueDefinitionIDs.ToArray(), args, requester, keys, dbTimeSeriesResult);

            return dbTimeSeriesResult;
        }

        protected abstract void Read(int[] entities, int[] timeseries, int[] relationship, DatabaseRequestArgs args, TimeSeriesDatabaseContext requester, Dictionary<QuickID, ITimeSeriesKey> keys, SortedList<ITimeSeriesKey, ITimeSeries> dbTimeSeriesResult);


        public SqlParameter[] GetParameters(int[] entities, int[] factors, int[] relationships, DatabaseRequestArgs args) => new SqlParameter[]
            {
                new SqlParameter("@EntityIDs", DataManipulation.ToCSVString(entities)),
                new SqlParameter("@TimeSeriesValueIDs", DataManipulation.ToCSVString(factors)),
                new SqlParameter("@RelationshipValueIDs", DataManipulation.ToCSVString(relationships)),
                new SqlParameter("@IAAD", args.Iterator.Iaad),
                new SqlParameter("@StartDate", args.Iterator.StartDate),
                new SqlParameter("@StartOffset", args.Iterator.StartOffset),
                new SqlParameter("@EndDate", args.Iterator.EndDate),
                new SqlParameter("@EndOffset", args.Iterator.EndOffset)
            };

        public SqlParameter[] GetCharacteristicParameters(int[] entities, int[] factors, int[] relationships, DatabaseRequestArgs args) => new SqlParameter[]
            {
                new SqlParameter("@EntityIDs", DataManipulation.ToCSVString(entities)),
                new SqlParameter("@TimeSeriesValueIDs", DataManipulation.ToCSVString(factors)),
                new SqlParameter("@RelationshipValueIDs", DataManipulation.ToCSVString(relationships))
            };
    }
}