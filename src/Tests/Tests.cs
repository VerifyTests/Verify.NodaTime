using System;
using System.Threading.Tasks;
using NodaTime;
using VerifyTests;
using VerifyXunit;
using Xunit;

[UsesVerify]
public class Tests
{
    [Fact]
    public Task DontScrub()
    {
        return Verifier.Verify(new AnnualDate(10, 10)).DontScrubNodaTimes();
    }

    [Fact]
    public Task AnnualDateValue()
    {
        return Verifier.Verify(new AnnualDate(10, 10));
    }

    [Fact]
    public Task InstantValue()
    {
        return Verifier.Verify(Instant.FromDateTimeUtc(DateTime.UtcNow));
    }

    [Fact]
    public Task LocalDateValue()
    {
        return Verifier.Verify(LocalDate.FromDateTime(DateTime.Now));
    }

    [Fact]
    public Task LocalDateTimeValue()
    {
        return Verifier.Verify(LocalDateTime.FromDateTime(DateTime.Now));
    }

    #region Example

    [Fact]
    public Task ScrubbingExample()
    {
        var target = new Person
        {
            Dob = LocalDateTime.FromDateTime(DateTime.Now)
        };

        return Verifier.Verify(target);
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

        return Verifier.Verify(target)
            .DontScrubNodaTimes();
    }

    #endregion

    public class Person
    {
        public LocalDateTime Dob { get; set; }
    }

    [Fact]
    public Task OffsetDateValue()
    {
        return Verifier.Verify(new OffsetDate(LocalDate.MinIsoValue, Offset.Zero));
    }

    [Fact]
    public Task ZonedDateTimeValue()
    {
        return Verifier.Verify(new ZonedDateTime(Instant.FromDateTimeUtc(DateTime.UtcNow), DateTimeZone.Utc));
    }

    [Fact]
    public Task YearMonthValue()
    {
        return Verifier.Verify(new YearMonth(10, 10));
    }
}