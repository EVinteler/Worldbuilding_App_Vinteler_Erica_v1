using System;
using System.Collections.Generic;
using System.Text;

using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Worldbuilding_App_Vinteler_Erica_v1.Models
{
    public class Story
    {
        [PrimaryKey, AutoIncrement]
        public int StoryID { get; set; }
        [Unique, NotNull]
        public string StoryName { get; set; }
        public string StoryGenre { get; set; }
        public string StoryPlotDesc { get; set; }

        public int WorldID { get; set; }
        [OneToMany]
        public List<Character> CharacterID { get; set; }
    }
}