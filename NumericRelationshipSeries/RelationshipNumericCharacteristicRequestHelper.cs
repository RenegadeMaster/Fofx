using System;
using System.Collections.Generic;

namespace Fofx
{
  public class RelationshipNumericCharacteristicRequestHelper : BaseRelationshipRevisableRequestHelper, ITimeSeriesRequestHelper
  {
    public override INullableReader GetDataReader(int[] entites, int[] factors, DatabaseRequestArgs args)
    {
      throw new NotImplementedException();
    }

    public override INullableReader GetDataReader(int[] entites, int[] factors, int[] relationships, DatabaseRequestArgs args)
    {
      var parameters = GetCharacteristicParameters(entites, factors, relationships, args);
      return DataAccess.GetDataReader("[TimeSeries].[RelationshipCharacteristicNumericTimeseriesLoad]", parameters);
    }

    public override ITimeSeries CreateNew(ITimeSeriesIterator itearator, TimeSeriesDescriptor factor)
    {
      return new NumericCharacteristicRevisableTimeSeries();
    }
    
    public override void Add(ITimeSeries iTimeSeries, INullableReader reader, DatabaseRequestArgs args, TimeSeriesDatabaseContext requester)
    {
      int toEntityID = reader.GetInt32(2);
      string value = reader.GetString(5);
      int? nonKeyedAttributeSetId = reader.GetNullableInt32(7);

      NonKeyedAttributeSet nonKeyedAttributeSet = null;
      if (nonKeyedAttributeSetId != null)
        nonKeyedAttributeSet = args.Translator.GetNonKeyedAttributeSet((int)nonKeyedAttributeSetId);

      IEntityDescriptor entity = null;
      if (!requester.EntityLookup.TryGetValue(toEntityID, out entity))
      {
        if (!args.Translator.TryGetEntityDescriptorByID(toEntityID, out entity))
          entity = new EntityDescriptor(toEntityID);
      }

      ((NumericCharacteristicRevisableTimeSeries)iTimeSeries).Add(entity, FofxConstants.MinimumDate, FofxConstants.MinimumDate, value, nonKeyedAttributeSet);
    }

    protected override void Read(int[] entities, int[] timeseries, int[] relationship, DatabaseRequestArgs args, TimeSeriesDatabaseContext requester, Dictionary<QuickID, ITimeSeriesKey> keys, SortedList<ITimeSeriesKey, ITimeSeries> dbTimeSeriesResult)
    {
      NumericCharacteristicRevisableTimeSeries ncs = null;
      ITimeSeries referenceTimeSeries = null;
      ITimeSeriesKey referenceKey = null;

      Preference codeTypePreference = null;
      int previousEntityID = -1;
      int previousTimeSeriesValueID = -1;
      int previousRelationshipValueID = -1;

      Revision<CharacteristicNumericPoint> revisionCollection = null;
      CharacteristicNumericPoint constituentPoint = null;

      using (INullableReader reader = GetDataReader(entities, timeseries, relationship, args))
      {
        while (reader.Read())
        {
          int entityID = reader.GetInt32(0);
          int timeSeriesValueID = reader.GetInt32(1);
          int relationshipValueID = reader.GetInt32(2);
          int toEntityID = reader.GetInt32(3);
          DateTime valueDate = reader.GetDateTime(4);
          DateTime declarationDate = reader.GetDateTime(5);
          double? value = reader.GetNullableDouble(6);
          int? nonKeyedAttributeSetId = reader.GetNullableInt32(7);

          NonKeyedAttributeSet nonKeyedAttributeSet = null;
          if (nonKeyedAttributeSetId != null)
            nonKeyedAttributeSet = args.Translator.GetNonKeyedAttributeSet((int)nonKeyedAttributeSetId);

          IEntityDescriptor entity = null;

          if (entityID != previousEntityID || previousTimeSeriesValueID != timeSeriesValueID || previousRelationshipValueID != relationshipValueID)
          {
            QuickID qid = new QuickID(entityID, timeSeriesValueID, relationshipValueID);
            if (keys.TryGetValue(qid, out referenceKey))
            {
              RelationshipTimeSeriesKey tsk = referenceKey as RelationshipTimeSeriesKey;
              if (tsk == null || tsk.Relationship == null || tsk.Relationship.Source == null)
                codeTypePreference = null;
              else
              {
                if (codeTypePreference != null && tsk.Relationship.Source.CodePreference != null)
                {
                  if (codeTypePreference.Id != tsk.Relationship.Source.CodePreference.Id)
                    requester.EntityLookup.Clear();

                  codeTypePreference = tsk.Relationship.Source.CodePreference;
                }
                else
                {
                  requester.EntityLookup.Clear();
                  codeTypePreference = tsk.Relationship.Source.CodePreference;
                }
              }
            }

            qid = new QuickID(previousEntityID, previousTimeSeriesValueID, previousRelationshipValueID);
            if (keys.TryGetValue(qid, out referenceKey))
            {
              if (dbTimeSeriesResult.TryGetValue(referenceKey, out referenceTimeSeries))
              {
                ncs = referenceTimeSeries as NumericCharacteristicRevisableTimeSeries;
                if (ncs != null)
                {
                  ncs.Add(revisionCollection);
                }
              }
            }

            revisionCollection = new Revision<CharacteristicNumericPoint>(valueDate);
            constituentPoint = new CharacteristicNumericPoint(nonKeyedAttributeSet);
            revisionCollection.Add(declarationDate, constituentPoint);
            previousEntityID = entityID;
            previousTimeSeriesValueID = timeSeriesValueID;
            previousRelationshipValueID = relationshipValueID;
          }

          if (!requester.EntityLookup.TryGetValue(toEntityID, out entity))
          {
            if (!args.Translator.TryGetEntityDescriptorByID(toEntityID, codeTypePreference, out entity))
              entity = new EntityDescriptor(toEntityID);
          }

          constituentPoint.Add(entity, value, nonKeyedAttributeSet);
        }
      }

      QuickID qid2 = new QuickID(previousEntityID, previousTimeSeriesValueID, previousRelationshipValueID);
      if (keys.TryGetValue(qid2, out referenceKey))
      {
        if (dbTimeSeriesResult.TryGetValue(referenceKey, out referenceTimeSeries))
        {
          ncs = referenceTimeSeries as NumericCharacteristicRevisableTimeSeries;
          if (ncs != null)
          {
            ncs.Add(revisionCollection);
          }
        }
      }
    }
  }
}
