# <img src="/src/icon.png" height="30px"> Verify.NodaTime

[![Discussions](https://img.shields.io/badge/Verify-Discussions-yellow?svg=true&label=)](https://github.com/orgs/VerifyTests/discussions)
[![Build status](https://ci.appveyor.com/api/projects/status/ej794va900x9257f?svg=true)](https://ci.appveyor.com/project/SimonCropp/Verify-NodaTime)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.NodaTime.svg)](https://www.nuget.org/packages/Verify.NodaTime/)

Adds [Verify](https://github.com/VerifyTests/Verify) support for scrubbing [NodaTime](https://nodatime.org/) values.

**See [Milestones](../../milestones?state=closed) for release notes.**


## NuGet

 * https://nuget.org/packages/Verify.NodaTime


## Usage

<!-- snippet: enable -->
<a id='snippet-enable'></a>
```cs
[ModuleInitializer]
public static void Init() =>
    VerifyNodaTime.Initialize();
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L3-L9' title='Snippet source file'>snippet source</a> | <a href='#snippet-enable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Then all Noda date/times will be scrubbed:

<!-- snippet: Example -->
<a id='snippet-Example'></a>
```cs
[Fact]
public Task ScrubbingExample()
{
    var target = new Person
    {
        Dob = LocalDateTime.FromDateTime(DateTime.Now)
    };

    return Verify(target);
}
```
<sup><a href='/src/Tests/Tests.cs#L23-L36' title='Snippet source file'>snippet source</a> | <a href='#snippet-Example' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Resulting in:

<!-- snippet: Tests.ScrubbingExample.verified.txt -->
<a id='snippet-Tests.ScrubbingExample.verified.txt'></a>
```txt
{
  Dob: LocalDateTime_1
}
```
<sup><a href='/src/Tests/Tests.ScrubbingExample.verified.txt#L1-L3' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.ScrubbingExample.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

To disable scrubbing use `DontScrubNodaTimes`:

<!-- snippet: Disable -->
<a id='snippet-Disable'></a>
```cs
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
```
<sup><a href='/src/Tests/Tests.cs#L38-L52' title='Snippet source file'>snippet source</a> | <a href='#snippet-Disable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Resulting in:

<!-- snippet: Tests.DisableExample.verified.txt -->
<a id='snippet-Tests.DisableExample.verified.txt'></a>
```txt
{
  Dob: DateTimeOffset_1
}
```
<sup><a href='/src/Tests/Tests.DisableExample.verified.txt#L1-L3' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.DisableExample.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Clock](https://thenounproject.com/term/clock/731041/) designed by [Mooyai Khomsun Chaiwong](https://thenounproject.com/mooyai/) from [The Noun Project](https://thenounproject.com/).
