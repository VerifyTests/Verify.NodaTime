class YearMonthConverter :
    WriteOnlyJsonConverter<YearMonth>
{
    public override void Write(VerifyJsonWriter writer, YearMonth value)
    {
        if (!writer.Context.ScrubNodaTimes())
        {
            writer.Serialize(value.ToString());
            return;
        }

        var next = CounterContext.Current.Next(value);
        writer.WriteValue($"YearMonth_{next}");
    }
}