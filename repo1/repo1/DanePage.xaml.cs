using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace repo1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DanePage : ContentPage
    {
        public DanePage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listaBMI.ItemsSource = await App.Database.WyswietlUzytkownikaAsync();
        }

        private void Wroc_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}