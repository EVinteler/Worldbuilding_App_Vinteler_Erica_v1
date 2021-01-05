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

        // functiile din pagina noastra curenta sunt apelate cu ajutorul butoanelor/a altor interactiuni
        // si la randul lor vor apela functiile ce le-am scris la WorldbuildingDatabase
        async void OnStorySaveButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnStorySaveButtonClicked", "Opened [OnStorySaveButtonClicked].", "Ok.");

            // variabila vstory va primi elementul de tip world transmis prin BindingContext de la pagina ListEntryPage
            // cand a apelat functia de a crea aceasta pagina
            // si va fi transmis ca argument la functia de SaveStory
            var vstory = (Story)BindingContext;
            await App.Database.SaveStoryAsync(vstory);
            // POPasync ne trimite la pagina anterioara din stack-ul de pagini de navigare
            await Navigation.PopAsync();
        }

        async void OnStoryDeleteButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnStoryDeleteButtonClicked", "Opened [OnStoryDeleteButtonClicked].", "Ok.");

            // variabila vstory va primi elementul de tip world transmis prin BindingContext de la pagina ListEntryPage
            // cand a apelat functia de a crea aceasta pagina
            // si va fi transmis ca argument la functia de DeleteStory
            var vstory = (Story)BindingContext;
            await App.Database.DeleteStoryAsync(vstory);
            // POPasync ne trimite la pagina anterioara din stack-ul de pagini de navigare
            await Navigation.PopAsync();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();

                //var vstory = (Story)BindingContext;
                //var worldlbl=App.Database.GetStoryWorldIDAsync(vstory);
                //App.Database.GetStoryWorldIDAsync(vstory);
                //labelViewStoryWorld.Text = (String)worldlbl;

            // la partea de baza de la functia OnAppearing() adaugam si
            // o afisare a elementelor din tabelul World si Character la
            // listele respective
            listViewWorld.ItemsSource = await App.Database.GetWorldListAsync();
            listViewCharacter.ItemsSource = await App.Database.GetCharacterListAsync();
        }

        // la apasarea pe un element World din lista, apelam functia de mai jos care ne insereaza numele respectiv in tabelul Story
        async void OnWorldChooseButtonClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null) // daca elementul World selectat nu este null
            {
                // worldd va contine itemul selectat sub forma de/convertit ca element de tip World
                var worldd = (World)e.SelectedItem;
                // vstory va fi elementul de tip Story de pe pagina curenta, luat de la pagina anterioara,
                // ListEntryPage care a transmis elementul respectiv story cand a creat o pagina (/noua) de tip ListPageStories
                var vstory = (Story)BindingContext;

                //await DisplayAlert("OnWorldChooseButtonClicked", "World: " + worldd.WorldID + " Story: " + vstory.StoryID, "Ok.");

                // apelam functia de mai jos si transmitem ca argumente numele elementului World si elementul Story curent
                // pe care vrem sa il updatam
                await App.Database.SelectFromWorldListAsync(worldd.WorldName, vstory);
            }
        }

        // la apasarea pe un element Character din lista, apelam functia de mai jos care ne insereaza numele respectiv in tabelul Story
        async void OnCharacterChooseButtonClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null) // daca elementul Character selectat nu este null
            {
                // worldd va contine itemul selectat sub forma de element de tip World
                var charad = (Character)e.SelectedItem;
                // vstory va fi elementul de tip Story de pe pagina curenta, luat de la pagina anterioara,
                // ListEntryPage care a transmis elementul respectiv story cand a creat o pagina (/noua) de tip ListPageStories
                var vstory = (Story)BindingContext;

                // apelam functia de mai jos si transmitem ca argumente numele elementului Character si elementul Story curent
                // pe care vrem sa il updatam
                await App.Database.SelectFromCharacterListAsync(charad.CharacterName, vstory);
            }
        }
    }
}