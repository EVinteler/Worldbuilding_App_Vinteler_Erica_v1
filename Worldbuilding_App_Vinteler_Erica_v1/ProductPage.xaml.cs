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
    public partial class ProductPage : ContentPage
    {
        World wd;
        public ProductPage(World vworld)
        {
            InitializeComponent();
            wd = vworld;
        }
        async void OnWorldSaveButtonClicked(object sender, EventArgs e)
        {
            var world = (World)BindingContext;
            await App.Database.SaveWorldAsync(world);
            listView.ItemsSource = await App.Database.GetWorldListAsync();
        }
        async void OnWorldDeleteButtonClicked(object sender, EventArgs e)
        {
            var world = (World)BindingContext;
            await App.Database.DeleteWorldAsync(world);
            listView.ItemsSource = await App.Database.GetWorldListAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetWorldListAsync();
        }
        /*
        async void OnWorldViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            World w;
            if (e.SelectedItem != null)
            {
                w = e.SelectedItem as World;
                var lp = new ListProduct()
                {
                    ShopListID = wd.ID,
                    ProductID = w.ID
                };
                await App.Database.SaveWorldAsync(lp);
                p.ListProducts = new List<ListProduct> { lp };

                await Navigation.PopAsync();
            }
        }
        */
    }
}