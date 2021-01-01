using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using System.Threading.Tasks;
using Worldbuilding_App_Vinteler_Erica_v1.Models;

namespace Worldbuilding_App_Vinteler_Erica_v1.Data
{
    public class WorldbuildingDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public WorldbuildingDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<World>().Wait();
            _database.CreateTableAsync<Character>().Wait();
            _database.CreateTableAsync<Story>().Wait();
        }
        // Task returneaza un obiect async, in cazul nostru de tip int
        public Task<int> SaveWorldAsync(World world)
        {
            if (world.WorldID != 0)
            {
                // in cazul in care exista un element world cu id-ul resp, doar facem update la world in loc sa cream unul nou
                return _database.UpdateAsync(world);
            }
            else
            {
                // in cazut in care nu mai exista element world cu id-ul resp, il cream
                return _database.InsertAsync(world);
            }
        }
        public Task<int> DeleteWorldAsync(World world)
        {
            return _database.DeleteAsync(world);
        }
        public Task<List<World>> GetWorldListAsync()
        {
            // returneaza o lista de obiecte world
            return _database.Table<World>().ToListAsync();
        }
        public Task<World> GetWorldAsync(int id)
        {
            // returneaza un obiect de tip world dupa id
            return _database.Table<World>()
            .Where(i => i.WorldID == id)
           .FirstOrDefaultAsync();
        }
        /*
         * ne trebuie ^ si pentru Character si Story & poate si v
        public Task<List<Product>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Product>(
            "select P.ID, P.Description from Product P"
            + " inner join ListProduct LP"
            + " on P.ID = LP.ProductID where LP.ShopListID = ?",
            shoplistid);
        }
        */
    }
}
