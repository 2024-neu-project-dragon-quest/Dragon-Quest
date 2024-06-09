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
        private double[][] urm; // uniform range map
        private int[] spm; // selection probability map

        public RandomValue(string range) {

            /*
            
                2->10@20%;69;45->50;420@69%
            
            */

            string[] ranges = range.Split(";");
            this.ranges = new double[ranges.Length][];

            this.spm = new int[ranges.Length];

            for (int i = 0; i < ranges.Length; i++) {

                string r = ranges[i];
                string[] sRangeProbability = r.Split("@");
                if (sRangeProbability.Length > 1)
                    spm[i] = int.Parse(sRangeProbability[1].Replace("%", ""));
                else spm[i] = 100;

                string[] sRange = sRangeProbability[0].Split("->");
                if (sRange.Length < 2) {

                    this.ranges[i] = new double[] {double.Parse(sRangeProbability[0]), double.Parse(sRangeProbability[0])};
                    continue;

                }

                this.ranges[i] = new double[] {double.Parse(sRange[0]), double.Parse(sRange[1])};

            }

            this.urm = GetUniformRangeMap();

        }

        private int[] GetRangeDifferenceMap() {

            /*
            
                zraphy dont forget to add weighted probabilities, just simply multiply the range difference by the probability (like @10%), if theres no probability set, dont multiply it, just leave blud be
                inshallah
            
            */

            int[] rangeDiffMap = new int[this.ranges.Length];
            for (int i = 0; i < this.ranges.Length; i++) {

                int diff = (int) Math.Round(this.ranges[i][1] - this.ranges[i][0]);
                diff = diff == 0 ? 1 : diff;
                rangeDiffMap[i] = diff * this.spm[i];

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

        private double GetRandomValueFromRange(double[] range) {

            double rangeDiff = range[1] - range[0];
            return rangeDiff * new Random().NextDouble() + range[0];

        }

        public double SingleProbabilisticDoubleSelection() {

            double[] randomRange = GetRandomRange();
            return GetRandomValueFromRange(randomRange);

        }

        public int SingleProbabilisticIntegerSelection() { return (int) Math.Round(SingleProbabilisticDoubleSelection()); }

        public List<double> ProbabilisticDoubleSelection() {

            List<double> selection = new List<double>();
            for (int i = 0; i < this.ranges.Length; i++) {

                double random = new Random().NextDouble();
                if (random <= (double) this.spm[i] / 100.0) selection.Add(GetRandomValueFromRange(this.ranges[i]));
                //Console.WriteLine("random = " + random + "\nthis.spm[i] / 100.0 = " + (double) this.spm[i] / 100.0);

            }

            return selection;

        }

        public List<int> ProbabilisticIntegerSelection() {

            List<int> selection = new List<int>();
            /*for (int i = 0; i < this.ranges.Length; i++) {

                double random = new Random().NextDouble();
                if (random <= this.spm[i] / 100) selection.Add((int) Math.Round(GetRandomValueFromRange(this.ranges[i])));

            } THIS HERE IS WAAAAYYY TOO BISMILLAH, its good because its more efficient but i am a sigma and i do whatever it is thats on the lines below*/

            foreach (double d in ProbabilisticDoubleSelection()) selection.Add((int) Math.Round(d));
            return selection;

        }

    }

}