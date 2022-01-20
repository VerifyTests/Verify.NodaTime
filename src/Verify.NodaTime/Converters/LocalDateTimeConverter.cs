using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

class LocalDateTimeConverter :
    WriteOnlyJsonConverter<LocalDateTime>
{
    public override void Write(VerifyJsonWriter writer, LocalDateTime value, JsonSerializer serializer)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.LocalDateTimeConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"LocalDateTime_{next}");
    }
}