namespace Video_001_Components.SDK;


public static class ServicesProvider
{
    private static IServiceProvider _current;

    public static TService GetService<TService>()
        => Current.GetService<TService>();

    public static IServiceProvider Current
        => _current ??= CreateServiceProvider();

    private static IServiceProvider CreateServiceProvider()
    {
#if WINDOWS10_0_17763_0_OR_GREATER
        return MauiWinUIApplication.Current.Services;
#elif ANDROID
        return MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        return MauiUIApplicationDelegate.Current.Services;
#else
        return null;
#endif
    }

    public static void Reset()
    {
        if (_current is IDisposable disposable)
        {
            disposable.Dispose();
        }
        _current = null;
    }
}
