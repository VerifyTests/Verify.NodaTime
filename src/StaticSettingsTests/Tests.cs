public class Tests
{
    [Fact]
    public Task AnnualDateValue() =>
        Verify(new AnnualDate(10, 10));

    [Fact]
    public Task InstantValue() =>
        Verify(Instant.FromDateTimeUtc(new(2020,10,1, 12, 0, 0, 0, DateTimeKind.Utc)));

    [Fact]
    public Task LocalDateValue() =>
        Verify(LocalDate.FromDateTime(new(2020,10,1 )));

    [Fact]
    public Task LocalDateTimeValue() =>
        Verify(LocalDateTime.FromDateTime(new(2020,10,1 )));

    [Fact]
    public Task OffsetDateValue() =>
        Verify(new OffsetDate(LocalDate.MinIsoValue, Offset.Zero));

    [Fact]
    public Task ZonedDateTimeValue() =>
        Verify(new ZonedDateTime(Instant.FromDateTimeUtc(new(2020,10,1, 12, 0, 0, 0, DateTimeKind.Utc)), DateTimeZone.Utc));

    [Fact]
    public Task YearMonthValue() =>
        Verify(new YearMonth(10, 10));

    [Fact]
    public Task DateIntervalValue() =>
        Verify(new DateInterval(LocalDate.MinIsoValue, LocalDate.MaxIsoValue));
}