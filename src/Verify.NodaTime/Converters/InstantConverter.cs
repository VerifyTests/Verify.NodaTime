class InstantConverter :
    WriteOnlyJsonConverter<Instant>
{
    public override void Write(VerifyJsonWriter writer, Instant value)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.InstantConverter.WriteJson(writer, value, writer.Serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"Instant_{next}");
    }
}