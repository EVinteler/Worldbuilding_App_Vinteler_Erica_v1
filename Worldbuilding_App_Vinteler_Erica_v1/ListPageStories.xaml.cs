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
            //var worldd = (World)BindingContext;

            listViewWorld.ItemsSource = await App.Database.GetWorldListAsync();
        }
        
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