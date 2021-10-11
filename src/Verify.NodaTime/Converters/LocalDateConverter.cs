using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using VerifyTests;

class LocalDateConverter :
    WriteOnlyJsonConverter<LocalDate>
{
    public override void WriteJson(
        JsonWriter writer,
        LocalDate value,
        JsonSerializer serializer,
        IReadOnlyDictionary<string, object> context)
    {
        if (!context.ScrubNodaTimes())
        {
            NodaConverters.LocalDateConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"LocalDate_{next}");
    }
}