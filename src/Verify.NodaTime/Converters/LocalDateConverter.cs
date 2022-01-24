using NodaTime;
using NodaTime.Serialization.JsonNet;

class LocalDateConverter :
    WriteOnlyJsonConverter<LocalDate>
{
    public override void Write(VerifyJsonWriter writer, LocalDate value)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.LocalDateConverter.WriteJson(writer, value, writer.Serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"LocalDate_{next}");
    }
}