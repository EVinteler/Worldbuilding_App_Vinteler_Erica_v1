using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Worldbuilding_App_Vinteler_Erica_v1.Models;

namespace Worldbuilding_App_Vinteler_Erica_v1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPageCharacters : ContentPage
    {
        public ListPageCharacters()
        {
            InitializeComponent();
        }

        // apelam functiile din WorldbuildingDatabase
        async void OnCharacterSaveButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnCharacterSaveButtonClicked", "Opened [OnCharacterSaveButtonClicked].", "Ok.");
            var vchara = (Character)BindingContext;
            await App.Database.SaveCharacterAsync(vchara);
            await Navigation.PopAsync();
        }

        async void OnCharacterDeleteButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnCharacterDeleteButtonClicked", "Opened [OnCharacterDeleteButtonClicked].", "Ok.");
            var vchara = (Character)BindingContext;
            await App.Database.DeleteCharacterAsync(vchara);
            await Navigation.PopAsync();
        }
        /*
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var worldd = (World)BindingContext;

            listView.ItemsSource = await App.Database.GetWorldListAsync();
        }
        *.
        /*
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage((ShopList)
           this.BindingContext)
            {
                BindingContext = new Product()
            });

        }
        */
    }
}