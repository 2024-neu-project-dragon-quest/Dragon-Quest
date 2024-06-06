using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuest.Misc {

    public class RandomValue {
        
        private double[,] ranges;

        public RandomValue(string range) {

            string[] ranges = range.Split(";");
            this.ranges = new double[ranges.Length, 2];

            for (int i = 0; i < ranges.Length; i++) {

                string[] sRange = ranges[i].Split("-");
                this.ranges[i, 0] = double.Parse(sRange[0]);
                this.ranges[i, 1] = double.Parse(sRange[1]);

            }

        }

        private double RangeSum() {
            
            /* calculate the range sum here */
            return 69;
        
        }

        public double GetDouble() { return 69; }

        public int GetInt() { return 69; }

    }

}