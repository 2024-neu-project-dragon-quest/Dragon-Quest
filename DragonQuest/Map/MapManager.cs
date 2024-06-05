using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Misc;

namespace DragonQuest.Map {

    public class MapManager {

        // Init()

        // GetMapEntityByRGB()
        public static Entity? GetEntityByRGB(int r, int g, int b) {

            foreach (Entity entity in Entity.RGBCodedEntities)
                if (entity.RGBID == (r + ";" + g + ";" + b)) return entity;
            return null;

        }
        
    }

}