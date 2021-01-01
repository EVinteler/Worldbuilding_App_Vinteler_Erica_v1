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
            // care ne returneaza elemente de tip world, character si story
            
            //listView.ItemsSource = await App.Database.GetWorldListAsync();
            listViewCharacter.ItemsSource = await App.Database.GetCharacterListAsync();
            listViewStory.ItemsSource = await App.Database.GetStoryListAsync();

            // afiseaza si elementele story si characters tot aici dar cu culori diferite :D in .xaml
        }

            /*** WORLD ***/
        async void OnWorldAddedClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnWorldAddedClick", "Opened [OnWorldAddedClick].", "Ok.");
            // nw creeaza o noua pagina de tip Lista spre care trimitem ca argument
            // un nou element de tip World (o inregistrare in tabelul World)
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = new World()
            });
        }

        async void OnWorldViewItemSelected (object sender, SelectedItemChangedEventArgs e)
        {
            //await DisplayAlert("OnWorldViewItemSelected", "Opened [OnWorldViewItemSelected].", "Ok.");
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

            /*** CHARACTER ***/
        async void OnCharacterAddedClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnCharacterAddedClick", "Opened [OnCharacterAddedClick].", "Ok.");
            // nw creeaza o noua pagina de tip Lista spre care trimitem ca argument
            // un nou element de tip Character (o inregistrare in tabelul Character)
            await Navigation.PushAsync(new ListPageCharacters
            {
                BindingContext = new Character()
            });
        }

        async void OnCharacterViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //await DisplayAlert("OnCharacterViewItemSelected", "Opened [OnCharacterViewItemSelected].", "Ok.");
            // daca elementul selectat nu este null, cream o noua pagina de tip ListPage
            // unde argumentul e elementul nostru transmis ca element de tip Character
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPageCharacters
                {
                    BindingContext = e.SelectedItem as Character
                }
                );
            }
        }


            /*** STORY ***/
        async void OnStoryAddedClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnStoryAddedClick", "Opened [OnStoryAddedClick].", "Ok.");
            // nw creeaza o noua pagina de tip Lista spre care trimitem ca argument
            // un nou element de tip Story (o inregistrare in tabelul Story)
            await Navigation.PushAsync(new ListPageStories
            {
                BindingContext = new Story()
            });
        }

        async void OnStoryViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //await DisplayAlert("OnStoryViewItemSelected", "Opened [OnStoryViewItemSelected].", "Ok.");
            // daca elementul selectat nu este null, cream o noua pagina de tip ListPage
            // unde argumentul e elementul nostru transmis ca element de tip Story
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPageStories
                {
                    BindingContext = e.SelectedItem as Story
                }
                );
            }
        }
    }
}