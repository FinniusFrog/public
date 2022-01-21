
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using DropMenuTest.Core.ViewModels.Main;
using UIKit;
using System.Windows.Input;
using MvvmCross.Binding.BindingContext;

namespace DropMenuTest.iOS.Views.Main
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class MainViewController : BaseViewController<MainViewModel>
    {
        private UILabel _labelWelcome, _labelMessage;

        public ICommand OpenSecondViewCommand { get; set; }
        public ICommand TouchUpOpenSecondViewCommand { get; set; }

        protected override void CreateView()
        {
            _labelWelcome = new UILabel
            {
                Text = "Welcome!!",
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelWelcome);

            _labelMessage = new UILabel
            {
                Text = "Main View Controller",
                TextAlignment = UITextAlignment.Center
            };
            Add(_labelMessage);
        }

        protected override void LayoutView()
        {
            View.AddConstraints(new FluentLayout[]
           {
                _labelWelcome.WithSameCenterX(View),
                _labelWelcome.WithSameCenterY(View),

                _labelMessage.Below(_labelWelcome, 10f),
                _labelMessage.WithSameWidth(View)
           });
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<MainViewController, MainViewModel>();
            set.Bind(this).For(v => v.OpenSecondViewCommand).To(vm => vm.OpenSecondViewModel);
            set.Bind(this).For(v => v.TouchUpOpenSecondViewCommand).To(vm => vm.OpenSecondViewModel);
            set.Apply();


            var rightButton = new UIBarButtonItem("Doesnt Work", BuildMenuMain());
            UIBarButtonItem[] rightButtons = { rightButton };
            NavigationItem.SetRightBarButtonItems(rightButtons, false);

            var leftButton = new UIBarButtonItem( "Works", null);
            UIBarButtonItem[] leftButtons = { leftButton };
            NavigationItem.SetLeftBarButtonItems(leftButtons, false);

            leftButton.Clicked += LeftButton_Clicked;
        }

        private void LeftButton_Clicked(object sender, System.EventArgs e)
        {
            OpenSecondViewCommand.Execute(null);
        }

        private UIMenu BuildMenuMain()
        {
            var Action1 = UIAction.Create("Call", null, null, (arg) => { OpenSecondViewCommand.Execute(null); });
            return UIMenu.Create(new UIMenuElement[] { Action1 });
        }
    }
}
