using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

class LocalDateConverter :
    WriteOnlyJsonConverter<LocalDate>
{
    public override void Write(VerifyJsonWriter writer, LocalDate value, JsonSerializer serializer)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.LocalDateConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"LocalDate_{next}");
    }
}