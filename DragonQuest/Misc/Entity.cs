using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Misc;
using DragonQuest.Rendering;

namespace DragonQuest.Misc {

    public class Entity : ConfigMarkup {
        
        public static List<Entity> RGBCodedEntities = new List<Entity>();

        public string RGBID;
        public int ID;

        RenderableEntity allah; // do something about this zraphy

        public Entity(string path) : base(path) {

            this.ID = int.Parse(values["ID"]);
            this.RGBID = values["RGBID"];


            /*
            
            im supposed to add somthing here but i forgor
            
            */

        }

        // SetRenderableForm() -> this does shit with the RenderableEntity

    }

}