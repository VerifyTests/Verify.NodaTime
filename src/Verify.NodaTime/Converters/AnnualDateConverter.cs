using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;

class AnnualDateConverter :
    WriteOnlyJsonConverter<AnnualDate>
{
    public override void Write(VerifyJsonWriter writer, AnnualDate value, JsonSerializer serializer)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.AnnualDateConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"AnnualDate_{next}");
    }
}