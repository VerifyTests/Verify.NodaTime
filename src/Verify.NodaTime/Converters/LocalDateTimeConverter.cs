using System.Collections.Generic;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using VerifyTests;

class LocalDateTimeConverter :
    WriteOnlyJsonConverter<LocalDateTime>
{
    public override void WriteJson(
        JsonWriter writer,
        LocalDateTime value,
        JsonSerializer serializer,
        IReadOnlyDictionary<string, object> context)
    {
        if (!context.ScrubNodaTimes())
        {
            NodaConverters.LocalDateTimeConverter.WriteJson(writer, value, serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"LocalDateTime_{next}");
    }
}