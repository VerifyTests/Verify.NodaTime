using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

class InstantConverter :
    WriteOnlyJsonConverter<Instant>
{
    public override void Write(VerifyJsonWriter writer, Instant value, JsonSerializer serializer)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.InstantConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"Instant_{next}");
    }
}