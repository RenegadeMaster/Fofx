using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Fofx
{
  public class DatabaseRequestArgs
  {
    public readonly ITimeSeriesIterator Iterator;
    public readonly DataManipulation.Interpolation Interpolation;
    public readonly DataManipulation.Extrapolation Extrapolation;
    public readonly int SourceID;
    public readonly int RelationshipValueID;
    public readonly ITranslator Translator;

    public DatabaseRequestArgs(TimeSeriesRequest request, ITranslator translator)
    {
      Iterator = request.Iterator;
      if (request.TimeSeries != null)
      {
        Interpolation = request.TimeSeries.Interpolation;
        Extrapolation = request.TimeSeries.Extrapolation;

        if (request.TimeSeries.Source != null)
          SourceID = request.TimeSeries.Source.SourceID;
      }

      Translator = translator;
    }

    public DatabaseRequestArgs(RelationshipTimeSeriesRequest request, ITranslator translator)
    {
      Iterator = request.Iterator;
      if (request.TimeSeries != null)
      {
        Interpolation = request.TimeSeries.Interpolation;
        Extrapolation = request.TimeSeries.Extrapolation;

        if (request.TimeSeries.Source != null)
          SourceID = request.TimeSeries.Source.SourceID;
      }

      if (request.Relationship != null && request.Relationship.ValueDefinition != 0)
        RelationshipValueID = request.Relationship.ValueDefinition;

      Translator = translator;
    }
  }
}
