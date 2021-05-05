using System.Collections.Generic;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using VerifyTests;

class OffsetDateTimeConverter :
    WriteOnlyJsonConverter<OffsetDateTime>
{
    public override void WriteJson(
        JsonWriter writer,
        OffsetDateTime value,
        JsonSerializer serializer,
        IReadOnlyDictionary<string, object> context)
    {
        if (!context.ScrubNodaTimes())
        {
            NodaConverters.OffsetDateTimeConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"OffsetDateTime_{next}");
    }
}