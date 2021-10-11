using Newtonsoft.Json;
using NodaTime;
using VerifyTests;

class YearMonthConverter :
    WriteOnlyJsonConverter<YearMonth>
{
    public override void WriteJson(
        JsonWriter writer,
        YearMonth value,
        JsonSerializer serializer,
        IReadOnlyDictionary<string, object> context)
    {
        if (!context.ScrubNodaTimes())
        {
            writer.WriteValue(value);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"YearMonth_{next}");
    }
}