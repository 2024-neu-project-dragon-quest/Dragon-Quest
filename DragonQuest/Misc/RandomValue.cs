using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuest.Misc {

    public class RandomValue {
        
        /*
        
            THERE IS A PROBLEM WITH THIS:
        
            It's not all uniform probability.

            1-20;69

            69 has more probability than any of the numbers between 1-20

            UPDATE:

            okay i fixed it lol

        */

        private double[][] ranges;
        private double[][] urm;

        public RandomValue(string range) {

            string[] ranges = range.Split(";");
            this.ranges = new double[ranges.Length][];

            for (int i = 0; i < ranges.Length; i++) {

                string[] sRange = ranges[i].Split("-");
                if (sRange.Length < 2) {

                    this.ranges[i] = new double[] {double.Parse(ranges[i]), double.Parse(ranges[i])};
                    continue;

                }

                this.ranges[i] = new double[] {double.Parse(sRange[0]), double.Parse(sRange[1])};

            }

            this.urm = GetUniformRangeMap();

        }

        private int[] GetRangeDifferenceMap() {

            int[] rangeDiffMap = new int[this.ranges.Length];
            for (int i = 0; i < this.ranges.Length; i++) {

                int diff = (int) Math.Round(this.ranges[i][1] - this.ranges[i][0]);    
                rangeDiffMap[i] = diff == 0 ? 1 : diff;

            }

            return rangeDiffMap;

        }

        private int GetRangeSum() {

            int sum = 0;
            foreach (int rd in GetRangeDifferenceMap()) sum += rd;

            return sum;

        }

        private double[][] GetUniformRangeMap() {

            /* calculate the range sum here */
            double[][] urm = new double[GetRangeSum()][];
            int[] rdm = GetRangeDifferenceMap();

            int urmIndex = 0;
            for (int i = 0; i < rdm.Length; i++)
                for (int j = 0; j < rdm[i]; j++) {

                    urm[urmIndex] = new double[] {this.ranges[i][0], this.ranges[i][1]};
                    urmIndex++;

                }

            return urm;

        }

        private double[] GetRandomRange() {

            int randomRangeIndex = (int) (this.urm.Length * new Random().NextDouble());
            double rangeMin = this.urm[randomRangeIndex][0],
                   rangeMax = this.urm[randomRangeIndex][1];

            return new double[] {rangeMin, rangeMax}; 
        
        }

        public double GetDouble() {

            double[] randomRange = GetRandomRange();
            double rangeDiff = randomRange[1] - randomRange[0];

            return rangeDiff * new Random().NextDouble() + randomRange[0];

        }

        public int GetInt() { return (int) Math.Round(GetDouble()); }

    }

}