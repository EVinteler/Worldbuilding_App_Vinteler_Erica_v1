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

        // functiile din pagina noastra curenta sunt apelate cu ajutorul butoanelor/a altor interactiuni
        // si la randul lor vor apela functiile ce le-am scris la WorldbuildingDatabase
        async void OnCharacterSaveButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnCharacterSaveButtonClicked", "Opened [OnCharacterSaveButtonClicked].", "Ok.");

            // variabila vchara va primi elementul de tip world transmis prin BindingContext de la pagina ListEntryPage
            // cand a apelat functia de a crea aceasta pagina
            // si va fi transmis ca argument la functia de SaveCharacter
            var vchara = (Character)BindingContext;
            await App.Database.SaveCharacterAsync(vchara);
            // POPasync ne trimite la pagina anterioara din stack-ul de pagini de navigare
            await Navigation.PopAsync();
        }

        async void OnCharacterDeleteButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnCharacterDeleteButtonClicked", "Opened [OnCharacterDeleteButtonClicked].", "Ok.");

            // variabila vchara va primi elementul de tip world transmis prin BindingContext de la pagina ListEntryPage
            // cand a apelat functia de a crea aceasta pagina
            // si va fi transmis ca argument la functia de DeleteCharacter
            var vchara = (Character)BindingContext;
            await App.Database.DeleteCharacterAsync(vchara);
            // POPasync ne trimite la pagina anterioara din stack-ul de pagini de navigare
            await Navigation.PopAsync();
        }
    }
}