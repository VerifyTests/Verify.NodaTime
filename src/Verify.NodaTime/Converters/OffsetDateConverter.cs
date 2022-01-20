using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

class OffsetDateConverter :
    WriteOnlyJsonConverter<OffsetDate>
{
    public override void Write(VerifyJsonWriter writer, OffsetDate value, JsonSerializer serializer)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.OffsetDateConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"OffsetDate_{next}");
    }
}