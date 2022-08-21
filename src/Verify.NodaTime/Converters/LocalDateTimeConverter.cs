using NodaTime;
using Argon.NodaTime;

class LocalDateTimeConverter :
    WriteOnlyJsonConverter<LocalDateTime>
{
    public override void Write(VerifyJsonWriter writer, LocalDateTime value)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.LocalDateTimeConverter.WriteJson(writer, value, writer.Serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"LocalDateTime_{next}");
    }
}