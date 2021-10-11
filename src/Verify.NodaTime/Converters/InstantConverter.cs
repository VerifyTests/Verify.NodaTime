using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using VerifyTests;

class InstantConverter :
    WriteOnlyJsonConverter<Instant>
{
    public override void WriteJson(
        JsonWriter writer,
        Instant value,
        JsonSerializer serializer,
        IReadOnlyDictionary<string, object> context)
    {
        if (!context.ScrubNodaTimes())
        {
            NodaConverters.InstantConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"Instant_{next}");
    }
}