namespace VerifyTests.Converters;

using Argon.NodaTime;
using NodaTime;

public class DateIntervalConverter : WriteOnlyJsonConverter<DateInterval>
{
    public override void Write(VerifyJsonWriter writer, DateInterval value)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.DateIntervalConverter.WriteJson(writer, value, writer.Serializer);
            return;
        }

        var lowerNext = CounterContext.Current.Next(value.Start);
        var upperNext = CounterContext.Current.Next(value.End);
        writer.WriteValue($"DateInterval[LocalDate_{lowerNext}, LocalDate_{upperNext}]");
    }
}