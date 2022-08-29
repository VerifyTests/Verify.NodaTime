public static class ModuleInitializer
{
    #region enable

    [ModuleInitializer]
    public static void Init()
    {
        VerifyNodaTime.Enable();

        #endregion

        VerifyDiffPlex.Initialize();
    }
}