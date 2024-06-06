using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Misc;
using DragonQuest.Mob.AI;

namespace DragonQuest.Mob {

    public class Mob : Entity {
        
        public Behaviour b; // This shall be initialized in the constructor. Inshallah.
        public RandomValue damage; // This value can be 0 if the mob is not hostile.
        public double health;

        public Mob(string path) : base(path) {



        }

    }

}