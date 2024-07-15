using Controls.UserDialogs.Maui;

namespace MovieNest.Helpers
{
    public static class LoadingHepler
    {
        public static void Run()
        {
            UserDialogs.Instance.ShowHudImage("loading.gif", "Loading");
        }
        public static async void Stop()
        {
            await Task.Delay(5000);
            UserDialogs.Instance.HideHud();
        }
        public async static void Maintenance()
        {
            UserDialogs.Instance.ShowHudImage("baotri.gif", "Phim đang bảo trì");
            await Task.Delay(5000);
            UserDialogs.Instance.HideHud();
        }
    }
}
