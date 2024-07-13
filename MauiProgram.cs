using CommunityToolkit.Maui;
using DevExpress.Maui;
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
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .UseDevExpress()
                .UseDevExpressCollectionView()
                .UseDevExpressControls()
                .UseDevExpressEditors()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("fa-duotone-900.ttf", "FAD");
                    fonts.AddFont("fa-light-300.ttf", "FAL");
                    fonts.AddFont("fa-thin-100.ttf", "FAT");
                    fonts.AddFont("fa-brands.ttf", "FAB");
                    fonts.AddFont("fa-regular.ttf", "FAR");
                    fonts.AddFont("fa-solid.ttf", "FAS");
                    fonts.AddFont("Roboto-Black.ttf", "RB");
                    fonts.AddFont("Roboto-BlackItalic.ttf", "RBI");
                    fonts.AddFont("Roboto-Bold.ttf", "RBold");
                    fonts.AddFont("Roboto-BoldItalic.ttf", "RBIta");
                    fonts.AddFont("Roboto-Italic.ttf", "RI");
                    fonts.AddFont("Roboto-Light.ttf", "RL");
                    fonts.AddFont("Roboto-LightItalic.ttf", "RLI");
                    fonts.AddFont("Roboto-Medium.ttf", "RM");
                    fonts.AddFont("Roboto-MediumItalic.ttf", "RMI");
                    fonts.AddFont("Roboto-Regular.ttf", "RR");
                    fonts.AddFont("Roboto-Thin.ttf", "RT");
                    fonts.AddFont("Roboto-ThinItalic.ttf", "RTI");
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
