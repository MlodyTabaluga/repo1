using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace repo1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
        private async void Zapisz_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(imietxt.Text) && !string.IsNullOrWhiteSpace(nazwiskotxt.Text))
            {
                await App.Database.ZapiszUzytkownikaAsync(new Uzytkownik
                {
                    Imie = imietxt.Text,
                    Nazwisko = nazwiskotxt.Text,
                    BMI = double.Parse(BMI.Text),
                });

                imietxt.Text = nazwiskotxt.Text = string.Empty;
                await DisplayAlert("Sukces", "Dodano dane do bazy!", "OK");
            }
            else
                await DisplayAlert("Błąd", "Aby zapisać musisz wpisać imie i nazwisko!", "OK");
        }

        private void ZobaczListe_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DanePage());
        }
    }
}
