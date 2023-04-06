using System;
using System.Collections.Generic;

namespace Fofx
{
    public interface IConstituentTimeSeries : ITimeSeries
    {
        void AddValue(DateTime date, object value);

        IEnumerable<IEntityDescriptor> GetConstituents(DateTime date);

        IEnumerable<IEntityDescriptor> GetConstituents();

        IEnumerable<IEntityDescriptor> GetConstituents(DateTime startDate, DateTime endDate);
    }

    public interface IConstituentDataTimeSeries : ITimeSeries
    {
        void Add(IEntityDescriptor entity, DateTime valueDate, DateTime declarationDate, object value, NonKeyedAttributeSet nonKeyedAttributeSet);

        bool AddSafe(IEntityDescriptor entity, DateTime valueDate, DateTime declarationDate, object value);

        IEnumerable<IEntityDescriptor> GetConstituents(DateTime startDate, DateTime endDate);

        IEnumerable<IEntityDescriptor> GetConstituents(DateTime date);

        IEnumerable<IEntityDescriptor> GetConstituents();

        ITimeSeries GetView(ITimeSeriesIterator iterator, DataManipulation.Interpolation interpolation, DataManipulation.Extrapolation extrapolation, IConstituentTimeSeries constituents, NonKeyedAttributeSet nonKeyedAttributes);

        bool IsValidValue(object value);

        IConstituentDataPoint GetPoint(DateTime valueDate, DateTime declarationDate, NonKeyedAttributeSet nonKeyedAttributeSet = null);
    }

    public interface IConstituentRevisableTimeSeries : IConstituentDataTimeSeries
    {
    }

    public interface ICharacteristicRevisableTimeSeries : IConstituentDataTimeSeries
    {
        void AddValue(IEntityDescriptor entityCode, object value, NonKeyedAttributeSet nonKeyedAttributeSet = null);
    }
}
