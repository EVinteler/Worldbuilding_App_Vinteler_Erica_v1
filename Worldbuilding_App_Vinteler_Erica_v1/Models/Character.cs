using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Worldbuilding_App_Vinteler_Erica_v1.Models
{
    public class Character
    {
        [PrimaryKey, AutoIncrement]
        public int CharacterID { get; set; }
        [NotNull]
        public string CharacterName { get; set; }
        public int CharacterAge { get; set; }
        public string CharacterGender { get; set; }
        public string CharacterTraits { get; set; }
        public string CharacterDesc { get; set; }
    }
}
