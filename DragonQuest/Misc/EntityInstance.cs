using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuest.Misc {

    /*
    
    okay so i didnt think this through:
    
    
    first of all, since the map gets rendered as an upscaled version of the collision map
    
    */

    public class EntityInstance {
        
        /*
        
        this is where all the data of one mobs instance is stored, like location, and shit
        
        */

        public Entity entity;
        public Map.Map map; // This may change if an entity switches to another map.

        public EntityInstance(Entity entity, Map.Map map) {

            this.entity = entity;
            this.map = map;

            this.map.loadedEntities.Add(this);

        }

        public void Tick() {

            /*
            
                This function may be overridden by functions in classes inheritting this one.
            
            */

        }

        public void Kill() {

            /*
            
                remove from map.loadedEntities and do other stuff, just remove it
            
            */

        }

    }

}