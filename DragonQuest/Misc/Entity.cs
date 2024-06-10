using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Misc;
using DragonQuest.Rendering;
using DragonQuest.Map;

namespace DragonQuest.Misc {

    public class Entity : ConfigMarkup {
        
        public static List<Entity> RGBCodedEntities = new List<Entity>();

        public string RGBID;
        public int ID;
        public string name;

        RenderableEntity allah; // do something about this zraphy
        // actually, this might not be necessary, im still cooking

        public Entity(string path) : base(path) {

            this.ID = int.Parse(values["ID"]);
            this.RGBID = values["RGBID"];
            this.name = values["Name"];

            /*
            
            im supposed to add somthing here but i forgor
            
            */

        }

        public EntityInstance LoadInstance(Map.Map map) {

            return new EntityInstance(this, map);

        }

        // Here we need a 

        // SetRenderableForm() -> this does shit with the RenderableEntity

    }

}