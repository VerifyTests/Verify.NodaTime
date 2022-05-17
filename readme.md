# <img src="/src/icon.png" height="30px"> Verify.NodaTime

[![Build status](https://ci.appveyor.com/api/projects/status/ej794va900x9257f?svg=true)](https://ci.appveyor.com/project/SimonCropp/Verify-NodaTime)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.NodaTime.svg)](https://www.nuget.org/packages/Verify.NodaTime/)

Adds [Verify](https://github.com/VerifyTests/Verify) support for scrubbing [NodaTime](https://nodatime.org/) values.


## NuGet package

https://nuget.org/packages/Verify.NodaTime/


## Usage

Before any tests have run call:

```
VerifyNodaTime.Enable();
```

Then all Noda date/times will be scrubbed:

<!-- snippet: Example -->
<a id='snippet-example'></a>
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
<sup><a href='/src/Tests/Tests.cs#L26-L39' title='Snippet source file'>snippet source</a> | <a href='#snippet-example' title='Start of snippet'>anchor</a></sup>
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
<a id='snippet-disable'></a>
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
<sup><a href='/src/Tests/Tests.cs#L41-L55' title='Snippet source file'>snippet source</a> | <a href='#snippet-disable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

Resulting in:

<!-- snippet: Tests.DisableExample.verified.txt -->
<a id='snippet-Tests.DisableExample.verified.txt'></a>
```txt
{
  Dob: 2010-02-10T00:00:00
}
```
<sup><a href='/src/Tests/Tests.DisableExample.verified.txt#L1-L3' title='Snippet source file'>snippet source</a> | <a href='#snippet-Tests.DisableExample.verified.txt' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Clock](https://thenounproject.com/term/clock/731041/) designed by [Mooyai Khomsun Chaiwong](https://thenounproject.com/mooyai/) from [The Noun Project](https://thenounproject.com/).
