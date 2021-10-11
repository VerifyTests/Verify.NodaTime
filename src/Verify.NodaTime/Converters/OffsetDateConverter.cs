using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using VerifyTests;

class OffsetDateConverter :
    WriteOnlyJsonConverter<OffsetDate>
{
    public override void WriteJson(
        JsonWriter writer,
        OffsetDate value,
        JsonSerializer serializer,
        IReadOnlyDictionary<string, object> context)
    {
        if (!context.ScrubNodaTimes())
        {
            NodaConverters.OffsetDateConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"OffsetDate_{next}");
    }
}