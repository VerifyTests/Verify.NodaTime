class ZonedDateTimeConverter :
    WriteOnlyJsonConverter<ZonedDateTime>
{
    JsonConverter zonedDateTimeConverter = NodaConverters.CreateZonedDateTimeConverter(DateTimeZoneProviders.Tzdb);

    public override void Write(VerifyJsonWriter writer, ZonedDateTime value)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            zonedDateTimeConverter.WriteJson(writer, value, writer.Serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"ZonedDateTime_{next}");
    }
}