using Microsoft.Extensions.Logging;

namespace MovieNest
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("fa-duotone-900.ttf", "FAD");
                    fonts.AddFont("fa-light-300.ttf", "FAL");
                    fonts.AddFont("fa-thin-100.ttf", "FAT");
                    fonts.AddFont("fa-brands.ttf", "FAB");
                    fonts.AddFont("fa-regular.ttf", "FAR");
                    fonts.AddFont("fa-solid.ttf", "FAS");
                    fonts.AddFont("Lato-Black.ttf", "LB");
                    fonts.AddFont("Lato-BlackItalic.ttf", "LBI");
                    fonts.AddFont("Lato-Bold.ttf", "LBO");
                    fonts.AddFont("Lato-BoldItalic.ttf", "LBOI");
                    fonts.AddFont("Lato-Italic.ttf", "LI");
                    fonts.AddFont("Lato-Light.ttf", "LL");
                    fonts.AddFont("Lato-LightItalic.ttf", "LLI");
                    fonts.AddFont("Lato-Regular.ttf", "LR");
                    fonts.AddFont("Lato-Thin.ttf", "LT");
                    fonts.AddFont("Lato-ThinItalic.ttf","LTI");
                })
                .ConfigureMauiHandlers(handlers =>
                 {
#if ANDROID
                        handlers.AddHandler(typeof(Shell), typeof(MovieNest.Platforms.Android.Services.CustomerShell));
#endif
                 });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
