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
    public partial class ListEntryPage : ContentPage
    {
        public ListEntryPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // pentru ca listView din .xaml sa stie care lista sa o afiseze, folosim functia din WorldbuildingDatabase
            // care ne returneaza elemente de tip world
            listView.ItemsSource = await App.Database.GetWorldListAsync();
        }
        async void OnWorldAddedClicked(object sender, EventArgs e)
        {
            // nw creeaza o noua pagina de tip Lista spre care trimitem ca argument
            // un nou element de tip World (o inregistrare in tabelul World
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = new World()
            });
        }

        async void OnWorldViewItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            // daca elementul selectat nu este null, cream o noua pagina de tip ListPage
            // unde argumentul e elementul nostru transmis ca element de tip World
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPage
                {
                    BindingContext = e.SelectedItem as World
                }
                );
            }
        }
    }
}