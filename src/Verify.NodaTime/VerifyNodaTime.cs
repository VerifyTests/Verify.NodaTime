namespace VerifyTests;

public static class VerifyNodaTime
{
    public static void Enable()
    {
        CounterContext.Init();
        VerifierSettings.ModifySerialization(settings =>
        {
            settings.AddExtraSettings(serializerSettings =>
            {
                var converters = serializerSettings.Converters;
                converters.Add(new AnnualDateConverter());
                converters.Add(new InstantConverter());
                converters.Add(new LocalDateConverter());
                converters.Add(new LocalDateTimeConverter());
                converters.Add(new OffsetDateConverter());
                converters.Add(new OffsetDateTimeConverter());
                converters.Add(new ZonedDateTimeConverter());
                converters.Add(new YearMonthConverter());
            });
        });
    }

    public static void DontScrubNodaTimes(this VerifySettings settings)
    {
        settings.Context["ScrubNodaTimes"] = false;
    }

    public static SettingsTask DontScrubNodaTimes(this SettingsTask settings)
    {
        settings.CurrentSettings.DontScrubNodaTimes();
        return settings;
    }

    internal static bool ScrubNodaTimes(this IReadOnlyDictionary<string, object> context)
    {
        if (context.TryGetValue("ScrubNodaTimes", out var value))
        {
            return (bool) value;
        }

        return true;
    }
}