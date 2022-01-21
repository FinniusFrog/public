using System;

using Android.App;
using Android.Runtime;
using MvvmCross.Platforms.Android.Views;
using DropMenuTest.Core;

namespace DropMenuTest.Droid
{
    #if DEBUG
    [Application(Debuggable = true)]
#else
    [Application(Debuggable = false)]
#endif
        public class MainApplication : MvxAndroidApplication<Setup, App>
    {
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}
