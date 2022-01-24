using NodaTime;
using NodaTime.Serialization.JsonNet;

class OffsetDateTimeConverter :
    WriteOnlyJsonConverter<OffsetDateTime>
{
    public override void Write(VerifyJsonWriter writer, OffsetDateTime value)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.OffsetDateTimeConverter.WriteJson(writer, value, writer.Serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"OffsetDateTime_{next}");
    }
}