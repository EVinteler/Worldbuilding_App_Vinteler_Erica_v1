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

            // dropped table bc i created it wrong lol
            // i tried to just modify the columns in the table, to delete the World.cs page and remake it
            // but it didn't work until i dropped the table
            //var connection = new SQLiteConnection(dbPath);
            //connection.DropTable<World>();
        }
             /*** WORLD ***/
        // Task returneaza un obiect async, in cazul nostru de tip int
        public Task<int> SaveWorldAsync(World world)
        {
            // este un try catch doar de forma, pt ca nu imi merge DisplayAlert sau
            // ceva override ca sa nu imi intre aplicatia in break mode, lol
            try
            {
                if (world.WorldID != 0)
                {
                    // in cazul in care exista un element world cu id-ul resp, doar facem update la world in loc sa cream unul nou=
                    return _database.UpdateAsync(world);
                }
                else
                {
                    // in cazut in care nu mai exista element world cu id-ul resp, il cream
                    return _database.InsertAsync(world);
                }
            }
            catch (Exception e)
            {
                //return _database.Rollback();
                 return Task.Delay(100).ContinueWith(t => 0);
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


            /*** CHARACTERS ***/
        // Task returneaza un obiect async, in cazul nostru de tip int
        public Task<int> SaveCharacterAsync(Character character)
        {
            try
            {
                if (character.CharacterID != 0)
                {
                    // in cazul in care exista un element Character cu id-ul resp, doar facem update la Character in loc sa cream unul nou
                    return _database.UpdateAsync(character);
                }
                else
                {
                    // in cazut in care nu mai exista element Character cu id-ul resp, il cream
                    return _database.InsertAsync(character);
                }
            }
            catch (Exception e)
            {
                return Task.Delay(100).ContinueWith(t => 0);
            }
        }
        public Task<int> DeleteCharacterAsync(Character character)
        {
            return _database.DeleteAsync(character);
        }
        public Task<List<Character>> GetCharacterListAsync()
        {
            // returneaza o lista de obiecte Character
            return _database.Table<Character>().ToListAsync();
        }
        public Task<Character> GetCharacterAsync(int id)
        {
            // returneaza un obiect de tip Character dupa id
            return _database.Table<Character>()
            .Where(i => i.CharacterID == id)
           .FirstOrDefaultAsync();
        }

            /*** STORY ***/
        // Task returneaza un obiect async, in cazul nostru de tip int
        public Task<int> SaveStoryAsync(Story story)
        {
            try
            {
                if (story.StoryID != 0)
                {
                    // in cazul in care exista un element Story cu id-ul resp, doar facem update la Story in loc sa cream unul nou
                    return _database.UpdateAsync(story);
                }
                else
                {
                    // in cazut in care nu mai exista element Story cu id-ul resp, il cream
                    return _database.InsertAsync(story);
                }
            }
            catch (Exception e)
            {
                return Task.Delay(100).ContinueWith(t => 0);
            }
        }
        public Task<int> DeleteStoryAsync(Story story)
        {
            return _database.DeleteAsync(story);
        }
        public Task<List<Story>> GetStoryListAsync()
        {
            // returneaza o lista de obiecte Story
            return _database.Table<Story>().ToListAsync();
        }
        public Task<Story> GetStoryAsync(int id)
        {
            // returneaza un obiect de tip Story dupa id
            return _database.Table<Story>()
            .Where(i => i.StoryID == id)
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
