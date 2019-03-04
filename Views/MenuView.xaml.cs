using System.Windows;
using System.Windows.Controls;
using FirstsStepsRUI.ViewModels;
using MahApps.Metro.Controls;
using ReactiveUI;

namespace FirstsStepsRUI.Views
{
    public partial class MenuView : UserControl, IViewFor<MenuViewModel>
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel",
            typeof (MenuViewModel), typeof (MenuView), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (MenuViewModel) value; }
        }

        public MenuViewModel ViewModel
        {
            get { return (MenuViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            //ViewModel.SelectedOption = e.InvokedItem as MenuOptionViewModel;
        }

        public int SelectedIndex
        {
            get
            {
                return HamburgerMenuControl.Items.IndexOf(ViewModel.SelectedOption);
            }
        }

        public MenuView()
        {
            InitializeComponent();
            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel,
                    vm => vm.Menu,
                    v => v.HamburgerMenuControl.ItemsSource));

                d(this.Bind(ViewModel,
                    vm => vm.SelectedOption,
                    v => v.HamburgerMenuControl.SelectedItem));

                d(this.OneWayBind(ViewModel,
                    vm => vm.IsAvailable,
                    v => v.HamburgerMenuControl.Visibility));

                //ViewModel.IsAvailable.WhenAnyValue(ViewModel.IsAvailable == true ? HamburgerMenuControl.SelectedIndex = 1 : );
            });
        }
    }
}
