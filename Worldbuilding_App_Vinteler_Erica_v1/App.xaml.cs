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
                    // daca nu exista baza de date de tipul nostru ^ (wbdatabase) o cream, folosind path-ul corespunzator
                    database = new WorldbuildingDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Worldbuilding.db3"));
                }
                // returnam baza de date existenta sau cea creata mai sus
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            // cream o noua pagina de navigare, de tip listentrypage
            // barbackgroundColor este pentru a schimba culoarea de la toolbar
            MainPage = new NavigationPage(new ListEntryPage())
            {
                BarBackgroundColor = Color.Black
            };
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
