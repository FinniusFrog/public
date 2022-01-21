using Foundation;
using MvvmCross.Platforms.Ios.Core;
using DropMenuTest.Core;

namespace DropMenuTest.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
