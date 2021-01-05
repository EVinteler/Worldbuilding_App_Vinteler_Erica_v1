using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using System.Threading.Tasks; //pt async
using Worldbuilding_App_Vinteler_Erica_v1.Models;

namespace Worldbuilding_App_Vinteler_Erica_v1.Data
{
    public class WorldbuildingDatabase
    {
        // cream un element de tip conexiune la o baza de date, de tip async
        readonly SQLiteAsyncConnection _database;
        public WorldbuildingDatabase(string dbPath) //constructorul:
        {
            // initializam elementul cu tipul precizat si deschidem o baza de date spre path-ul specificat
            _database = new SQLiteAsyncConnection(dbPath);

            // folosind conexiunea, apelam functia sql de creare a unui tabel
            // si cream (creem?? :( ) tabele de tipul world, character si story
            _database.CreateTableAsync<World>().Wait();
            _database.CreateTableAsync<Character>().Wait();
            _database.CreateTableAsync<Story>().Wait();

            // dropped table bc i created it wrong lol
            // i tried to just modify the columns in the table, to delete the World.cs page and remake it
            // but it didn't work until i dropped the table
            //var connection = new SQLiteConnection(dbPath);
            //connection.DropTable<Story>();
        }
             /*** WORLD ***/
        // Task returneaza un obiect async, in cazul nostru de tip int
        public Task<int> SaveWorldAsync(World world)
        {
            // este un try catch doar de forma, pt ca nu imi merge ceva override ca sa nu imi intre aplicatia in break mode, lol
            try
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
            catch (Exception e)
            {
                //return _database.Rollback();  // sigur se poate face unn rollback cumva, doar nu imi iese mie
                Console.WriteLine("SaveWorldAsync EXCEPTION: " + e);
                return Task.Delay(100).ContinueWith(t => 0);
            }
        }
        public Task<int> DeleteWorldAsync(World world)
        {
            // folosim functia de delete din sqlasyncconnection
            return _database.DeleteAsync(world);
        }
        public Task<List<World>> GetWorldListAsync()
        {
            // returneaza o lista de obiecte World
            return _database.Table<World>().ToListAsync();
        }
        public Task<World> GetWorldAsync(int id)
        {
            // returneaza un obiect de tip World dupa id
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
                Console.WriteLine("SaveCharacterAsync EXCEPTION: " + e);
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
                Console.WriteLine("SaveStoryAsync EXCEPTION: " + e);
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


        public Task<int> SelectFromWorldListAsync(string worldName, Story story)
        {
            // vom updata tabelul story cu WorldName-ul trimis
            // elementul story la field-ul Worldname va primi valoarea din variabila worldName

            story.WorldName = worldName;

                //Console.WriteLine("StoryWorldID: " + story.WorldID);
                //Console.WriteLine("Update: " + _database.UpdateAsync(story));
                //Console.WriteLine("Update: " + _database.QueryAsync<Story>("select StoryWorldID from Story"));
                //return Task.Delay(100).ContinueWith(t => 0);

            // folosim functia update la care trimitem elementul story, la care i-am schimbat
            // field-ul WorldName mai sus
            return _database.UpdateAsync(story);
        }
        public Task<int> SelectFromCharacterListAsync(string characterName, Story story)
        {
            // vom updata tabelul story cu CharacterName-ul trimis
            // elementul story la field-ul CharacterName va primi valoarea din variabila characterName

            story.MainCharacterName = characterName;

                //Console.WriteLine("StoryWorldID: " + story.WorldID);
                //Console.WriteLine("Update: " + _database.UpdateAsync(story));
                //Console.WriteLine("Update: " + _database.QueryAsync<Story>("select StoryWorldID from Story"));
                //return Task.Delay(100).ContinueWith(t => 0);

            // folosim functia update la care trimitem elementul story, la care i-am schimbat
            // field-ul CharacterName mai sus
            return _database.UpdateAsync(story);
        }
    }
}
