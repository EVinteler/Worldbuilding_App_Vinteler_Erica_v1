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

            //var vstory = (Story)BindingContext;
            //var worldlbl=App.Database.GetStoryWorldIDAsync(vstory);
            //App.Database.GetStoryWorldIDAsync(vstory);
            //labelViewStoryWorld.Text = (String)worldlbl;

            listViewWorld.ItemsSource = await App.Database.GetWorldListAsync();
            listViewCharacter.ItemsSource = await App.Database.GetCharacterListAsync();
        }
        async void OnWorldChooseButtonClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                // worldd va contine itemul selectat sub forma de element de tip World
                var worldd = (World)e.SelectedItem;
                // vstory va fi elementul de tip Story luat de pe pagina curenta
                var vstory = (Story)BindingContext;

                //await DisplayAlert("OnWorldChooseButtonClicked", "World: " + worldd.WorldID + " Story: " + vstory.StoryID, "Ok.");

                // la apasarea pe un element World, apelam functia de mai jos care ne insereaza id-ul respectiv in tabelul Story
                await App.Database.SelectFromWorldListAsync(worldd.WorldName, vstory);
            }
        }
        async void OnCharacterChooseButtonClicked(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                // worldd va contine itemul selectat sub forma de element de tip World
                var charad = (Character)e.SelectedItem;
                // vstory va fi elementul de tip Story luat de pe pagina curenta
                var vstory = (Story)BindingContext;

                // la apasarea pe un element Character, apelam functia de mai jos care ne insereaza id-ul respectiv in tabelul Story
                await App.Database.SelectFromCharacterListAsync(charad.CharacterName, vstory);
            }
        }
    }
}