using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightGearApp.interfaces;
using System.Threading.Tasks;

namespace FlightGearApp
{
    class FindCorrelation : IFindCorrelation
    {
        string name;
        List<float> values;

        public FindCorrelation(string name, List<float> values)
        {
            this.name = name;
            this.values = values;
        }

        public void setNameAndValues(string name, List<float> values)
        {
            this.name = name;
            this.values = values;
        }

        public float sum(List<float> a, int size)
        {
            float sumA = 0;
            for (int i = 0; i < size; i++)
            {
                sumA = sumA + a[i];
            }
            return sumA;
        }

        float ave(List<float> a, int size)
        {
            float sumA = sum(a, size);
            if ((float)size != 0)
            {
                return sumA / (float)size;
            }
            return 0;
        }

        // returns the variance of X and Y
        public float variance(List<float> x, int size)
        {
            float u = ave(x, size);
            float sumXX = 0;
            for (int i = 0; i < size; i++)
            {
                sumXX = sumXX + x[i] * x[i];
            }
            if (size != 0)
            {
                return sumXX / (float)size - u * u;
            }
            return 0;
        }

        // returns the covariance of X and Y
        public float cov(List<float> x, List<float> y, int size)
        {
            float aveX = ave(x, size);
            float aveY = ave(y, size);

            float sum = 0;
            for (int i = 0; i < size; i++)
            {
                float num = (x[i] - aveX) * (y[i] - aveY);
                sum = sum + num;
            }
            if ((float)size != 0)
            {
                return sum / (float)size;
            }
            return 0;
        }

        // returns the Pearson correlation coefficient of X and Y
        public float pearson(List<float> x, List<float> y, int size)
        {
            float covXY = cov(x, y, size);
            float varX = variance(x, size);
            float varY = variance(y, size);
            double sqrtX = Math.Sqrt(varX);
            double sqrtY = Math.Sqrt(varY);
            float pearsonResult = covXY / (float)(sqrtX * sqrtY);
            if (Double.IsNaN(pearsonResult))
            {
                return 0;
            }
            return covXY / (float)(sqrtX * sqrtY);
        }

        public string findCrr(Dictionary<string, List<float>> data, List<string> strings)
        {
            float max = 0;
            int size = this.values.Count;
            string returnValue = "";
            for (int i = 0; i < strings.Count; i++)
            {
                if (name == strings[i])
                {
                    continue;
                }
                if (Math.Abs(pearson(this.values, data[strings[i]], size)) >= max)
                {
                    max = Math.Abs(pearson(this.values, data[strings[i]], size));
                    returnValue = strings[i];
                }
            }
            return returnValue;
        }

        public Line linear_reg(List<float> x, List<float> y, int size)
        {
            float aveX = ave(x, size);
            float aveY = ave(y, size);

            float covXY = cov(x, y, size);
            float varX = variance(x, size);
            float a = covXY / varX;
            float b = aveY - a * aveX;
            return new Line(a, b);
        }
    }
}
