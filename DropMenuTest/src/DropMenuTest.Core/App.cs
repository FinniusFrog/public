using MvvmCross.IoC;
using MvvmCross.ViewModels;
using DropMenuTest.Core.ViewModels.Main;

namespace DropMenuTest.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
