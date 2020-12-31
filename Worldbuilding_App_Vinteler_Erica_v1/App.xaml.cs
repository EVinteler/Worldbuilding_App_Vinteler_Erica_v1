using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Worldbuilding_App_Vinteler_Erica_v1.Data;

namespace Worldbuilding_App_Vinteler_Erica_v1
{
    public partial class App : Application
    {
        static WorldbuildingDatabase database;
        public static WorldbuildingDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new WorldbuildingDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Worldbuilding.db3"));
                        /*
                   ShoppingListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "ShoppingList.db3"));*/
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
