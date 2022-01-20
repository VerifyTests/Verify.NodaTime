using Newtonsoft.Json;
using NodaTime;

class YearMonthConverter :
    WriteOnlyJsonConverter<YearMonth>
{
    public override void Write(VerifyJsonWriter writer, YearMonth value, JsonSerializer serializer)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            writer.WriteValue(value);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"YearMonth_{next}");
    }
}