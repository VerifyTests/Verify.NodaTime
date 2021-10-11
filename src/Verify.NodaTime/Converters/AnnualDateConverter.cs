using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using VerifyTests;

class AnnualDateConverter :
    WriteOnlyJsonConverter<AnnualDate>
{
    public override void WriteJson(
        JsonWriter writer,
        AnnualDate value,
        JsonSerializer serializer,
        IReadOnlyDictionary<string, object> context)
    {
        if (!context.ScrubNodaTimes())
        {
            NodaConverters.AnnualDateConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"AnnualDate_{next}");
    }
}