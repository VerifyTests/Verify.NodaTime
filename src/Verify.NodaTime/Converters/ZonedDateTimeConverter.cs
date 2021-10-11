using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using VerifyTests;

class ZonedDateTimeConverter :
    WriteOnlyJsonConverter<ZonedDateTime>
{
    JsonConverter zonedDateTimeConverter = NodaConverters.CreateZonedDateTimeConverter(DateTimeZoneProviders.Tzdb);

    public override void WriteJson(
        JsonWriter writer,
        ZonedDateTime value,
        JsonSerializer serializer,
        IReadOnlyDictionary<string, object> context)
    {
        if (!context.ScrubNodaTimes())
        {
            zonedDateTimeConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"ZonedDateTime_{next}");
    }
}