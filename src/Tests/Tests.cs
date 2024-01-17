using NodaTime;

public class Tests
{
    [Fact]
    public Task DontScrub() =>
        Verify(new AnnualDate(10, 10)).DontScrubNodaTimes();

    [Fact]
    public Task AnnualDateValue() =>
        Verify(new AnnualDate(10, 10));

    [Fact]
    public Task InstantValue() =>
        Verify(Instant.FromDateTimeUtc(DateTime.UtcNow));

    [Fact]
    public Task LocalDateValue() =>
        Verify(LocalDate.FromDateTime(DateTime.Now));

    [Fact]
    public Task LocalDateTimeValue() =>
        Verify(LocalDateTime.FromDateTime(DateTime.Now));

    #region Example

    [Fact]
    public Task ScrubbingExample()
    {
        var target = new Person
        {
            Dob = LocalDateTime.FromDateTime(DateTime.Now)
        };

        return Verify(target);
    }

    #endregion

    #region Disable

    [Fact]
    public Task DisableExample()
    {
        var target = new Person
        {
            Dob = LocalDateTime.FromDateTime(new(2010, 2, 10))
        };

        return Verify(target)
            .DontScrubNodaTimes();
    }

    #endregion

    public class Person
    {
        public LocalDateTime Dob { get; set; }
    }

    [Fact]
    public Task OffsetDateValue() =>
        Verify(new OffsetDate(LocalDate.MinIsoValue, Offset.Zero));

    [Fact]
    public Task ZonedDateTimeValue() =>
        Verify(new ZonedDateTime(Instant.FromDateTimeUtc(DateTime.UtcNow), DateTimeZone.Utc));

    [Fact]
    public Task YearMonthValue() =>
        Verify(new YearMonth(10, 10));
}