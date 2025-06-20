public static class ModuleInitializer
{
    #region GlobalDontScrub

    [ModuleInitializer]
    public static void Init()
    {
        VerifyNodaTime.DontScrub();
        VerifyNodaTime.Initialize();
    }

    #endregion

    [ModuleInitializer]
    public static void InitOther() =>
        VerifierSettings.InitializePlugins();
}