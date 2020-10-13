using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
            topBarView.BackgroundGradientStartPoint = new Point(0, 0);
            topBarView.BackgroundGradientEndPoint = new Point(1, 1);
            PopulateSampleLIst();
        }

        private void PopulateSampleLIst()
        {
            List<ContactData> contacts = new List<ContactData>();
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last see within a week" });
            contacts.Add(new ContactData { Name = "Margrat Whites", Location = "Orlando", LastSeen = "Last seen recently" });
            contacts.Add(new ContactData { Name = "Donald Davids", Location = "New York", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Janis Separators", Location = "New Hampshire", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last within a day" });
            contacts.Add(new ContactData { Name = "Jaco Morrison", Location = "New York", LastSeen = "Last within a day" });

            listData.ItemsSource = contacts;
        }
    }
}