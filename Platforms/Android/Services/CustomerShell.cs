using Android.Content.Res;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;

namespace MovieNest.Platforms.Android.Services
{
    public class CustomerShell : ShellRenderer
    {
        public CustomerShell()
        {

        }
        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new CustomerShellBottomViewAppearance();
        }
    }
    public class CustomerShellBottomViewAppearance : IShellBottomNavViewAppearanceTracker
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void ResetAppearance(BottomNavigationView bottomView)
        {
            throw new NotImplementedException();
        }

        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            bottomView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityUnlabeled;
            bottomView.ItemIconSize = 50;
            bottomView.SetBackgroundColor(Color.FromRgb(208, 183, 134).ToPlatform());
            bottomView.ItemIconTintList = ColorStateList.ValueOf(Colors.White.ToPlatform());

            BottomNavigationMenuView? bottomNavView = bottomView.GetChildAt(0) as BottomNavigationMenuView;
            if (bottomNavView != null)
            {
                for (int i = 0; i < bottomNavView.ChildCount; i++)
                {
                    var child = bottomNavView.GetChildAt(i);
                    if (child is BottomNavigationItemView item && item.Selected)
                    {
                        item.SetIconTintList(ColorStateList.ValueOf(Color.FromRgb(191, 157, 90).ToPlatform()));
                    }
                }
            }
        }

    }
}
