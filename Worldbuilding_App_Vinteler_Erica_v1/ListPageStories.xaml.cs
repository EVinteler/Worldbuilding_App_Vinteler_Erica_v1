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
    public partial class ListPageStories : ContentPage
    {
        public ListPageStories()
        {
            InitializeComponent();
        }

        // apelam functiile din WorldbuildingDatabase
        async void OnStorySaveButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnStorySaveButtonClicked", "Opened [OnStorySaveButtonClicked].", "Ok.");
            var vstory = (Story)BindingContext;
            await App.Database.SaveStoryAsync(vstory);
            await Navigation.PopAsync();
        }

        async void OnStoryDeleteButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnStoryDeleteButtonClicked", "Opened [OnStoryDeleteButtonClicked].", "Ok.");
            var vstory = (Story)BindingContext;
            await App.Database.DeleteStoryAsync(vstory);
            await Navigation.PopAsync();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listViewStoryWorld.ItemsSource = await App.Database.GetStoryListAsync();
            listViewWorld.ItemsSource = await App.Database.GetWorldListAsync();
        }
        async void OnWorldChooseButtonClicked(object sender, EventArgs e)
        {
            var worldd = (World)BindingContext;
            var vstory = (Story)this.BindingContext;

            // la apasarea pe un element World, apelam functia de mai jos care ne insereaza id-ul respectiv in tabelul Story
            await App.Database.SelectFromWorldListAsync(worldd.WorldID, vstory);
            

            //await Navigation.PopAsync();
            /*
            await Navigation.PushAsync(new ProductPage((ShopList)this.BindingContext)
            {
                BindingContext = new Product()
            });
            */
        }
    }
}