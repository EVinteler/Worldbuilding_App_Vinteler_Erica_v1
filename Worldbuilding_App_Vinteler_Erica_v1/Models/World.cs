using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Worldbuilding_App_Vinteler_Erica_v1.Models
{
    public class World
    {
        [PrimaryKey, AutoIncrement]
        public int WorldID { get; set; }
        [NotNull]
        public string WorldName { get; set; }
        public string WorldLore { get; set; }
    }
}
