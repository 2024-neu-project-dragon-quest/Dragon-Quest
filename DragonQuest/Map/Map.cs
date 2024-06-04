using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Misc;

namespace DragonQuest.Map {

    public class Map : ConfigMarkup {
        
        public int ID;
        public string name;
        public MapStructure structure;

        public Map(string path) : base(path) {

            this.ID = int.Parse(this.values["ID"]);
            this.name = this.values["MapName"];
            
            this.structure = new MapStructure("./Assets/map/" + this.values["MapStruct"]);

        }

    }

}