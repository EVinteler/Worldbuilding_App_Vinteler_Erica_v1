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
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        
        // functiile din pagina noastra curenta sunt apelate cu ajutorul butoanelor/a altor interactiuni
        // si la randul lor vor apela functiile ce le-am scris la WorldbuildingDatabase
        async void OnWorldSaveButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnWorldSaveButtonClicked", "Opened [OnWorldSaveButtonClicked].", "Ok.");

            // variabila vworld va primi elementul de tip world transmis prin BindingContext de la pagina ListEntryPage
            // cand a apelat functia de a crea aceasta pagina
            // si va fi transmis ca argument la functia de SaveWorld
            var vworld = (World)BindingContext;
            await App.Database.SaveWorldAsync(vworld);
            // POPasync ne trimite la pagina anterioara din stack-ul de pagini de navigare
            await Navigation.PopAsync();
        }

        async void OnWorldDeleteButtonClicked(object sender, EventArgs e)
        {
            //await DisplayAlert("OnWorldDeleteButtonClicked", "Opened [OnWorldDeleteButtonClicked].", "Ok.");

            // variabila vworld va primi elementul de tip world transmis prin BindingContext de la pagina ListEntryPage
            // cand a apelat functia de a crea aceasta pagina
            // si va fi transmis ca argument la functia de DeleteWorld
            var vworld = (World)BindingContext;
            await App.Database.DeleteWorldAsync(vworld);
            await Navigation.PopAsync();
        }
    }
}