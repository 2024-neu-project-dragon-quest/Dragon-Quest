using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Misc;

namespace DragonQuest.Mob {

    public class MobInstance : EntityInstance {
        
        /*
        
        this is where all the data of one mobs instance is stored, like location, and shit

        NEVER MIND

        all that stuff goes into EntityInstance.cs cus its not just mobs that can be entities
        
        */

        public MobInstance(Mob mob, Map.Map map) : base(mob, map) {



        }

    }

}