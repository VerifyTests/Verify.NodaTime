using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

class ZonedDateTimeConverter :
    WriteOnlyJsonConverter<ZonedDateTime>
{
    JsonConverter zonedDateTimeConverter = NodaConverters.CreateZonedDateTimeConverter(DateTimeZoneProviders.Tzdb);

    public override void Write(VerifyJsonWriter writer, ZonedDateTime value, JsonSerializer serializer)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            zonedDateTimeConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"ZonedDateTime_{next}");
    }
}