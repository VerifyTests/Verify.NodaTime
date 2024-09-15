class OffsetDateConverter :
    WriteOnlyJsonConverter<OffsetDate>
{
    public override void Write(VerifyJsonWriter writer, OffsetDate value)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            NodaConverters.OffsetDateConverter.WriteJson(writer, value, writer.Serializer);
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"OffsetDate_{next}");
    }
}