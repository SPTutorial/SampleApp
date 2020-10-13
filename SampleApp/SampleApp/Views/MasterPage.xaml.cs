using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleApp.Models;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new DashboardPage());
            PopulateMenu();
        }

        private void PopulateMenu()
        {
            List<MainMenu> menus = new List<MainMenu>();
            menus.Add(new MainMenu { MenuName = "Dashboard" });
            menus.Add(new MainMenu { MenuName = "List Page" });
            menus.Add(new MainMenu { MenuName = "Profile" });
            menus.Add(new MainMenu { MenuName = "Logout" });

            Mastermenu.ItemsSource = menus;
        }

        private void Mastermenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MainMenu selectedMenu = e.SelectedItem as MainMenu;
            if (selectedMenu != null)
            {
                switch (selectedMenu.MenuName)
                {
                    case "Dashboard":
                        Detail = new NavigationPage(new DashboardPage());
                        break;
                    case "List Page":
                        Detail = new NavigationPage(new ListPage());
                        break;
                    case "Profile":
                        Detail = new NavigationPage(new ProfilePage());
                        break;
                    case "Logout":
                        Application.Current.MainPage = new NavigationPage(new LoginPage());
                        break;
                }
            }
            IsPresented = false;
        }
    }
}