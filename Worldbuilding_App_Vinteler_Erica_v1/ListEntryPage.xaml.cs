using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; //pt async

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

            // elementele de la listViewStory vor avea valorile primite din GetStoryListAsync, metoda din WorldbuildingDatabase
            // folosim await pentru a pastra asincronicitatea (is that even a word?...) si pt ca avem async la functia noastra OnAppearing()
            // care face override la cea "de baza"
            
            listViewStory.ItemsSource = await App.Database.GetStoryListAsync();
            listView.ItemsSource = await App.Database.GetWorldListAsync();
            listViewCharacter.ItemsSource = await App.Database.GetCharacterListAsync();

        }

            /*** WORLD ***/
        async void OnWorldAddedClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnWorldAddedClick", "Opened [OnWorldAddedClick].", "Ok.");

            // PUSHasync ne adauga o noua pagina pe stack-ul de pagini de navigare
            // pagina va fi de tip ListPage spre care trimitem ca argument
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
            // unde argumentul este itemul selectat "e.selectedItem" ne-a fost transmis
            // pe care il transmitem ca element de tip World
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

            // ne adauga o noua pagina pe stack-ul de pagini de navigare
            // pagina va fi de tip ListPageCharacters spre care trimitem ca argument
            // un nou element de tip Character (o inregistrare in tabelul Character)
            await Navigation.PushAsync(new ListPageCharacters
            {
                BindingContext = new Character()
            });
        }

        async void OnCharacterViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //await DisplayAlert("OnCharacterViewItemSelected", "Opened [OnCharacterViewItemSelected].", "Ok.");

            // daca elementul selectat nu este null, cream o noua pagina de tip ListPageCharacters
            // unde argumentul este itemul selectat "e.selectedItem" ne-a fost transmis
            // pe care il transmitem ca element de tip Character
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

            // ne adauga o noua pagina pe stack-ul de pagini de navigare
            // pagina va fi de tip ListPageStories spre care trimitem ca argument
            // un nou element de tip Story (o inregistrare in tabelul Story)
            await Navigation.PushAsync(new ListPageStories
            {
                BindingContext = new Story()
            });
        }

        async void OnStoryViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //await DisplayAlert("OnStoryViewItemSelected", "Opened [OnStoryViewItemSelected].", "Ok.");

            // daca elementul selectat nu este null, cream o noua pagina de tip ListPageStories
            // unde argumentul este itemul selectat "e.selectedItem" ne-a fost transmis
            // pe care il transmitem ca element de tip Story
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