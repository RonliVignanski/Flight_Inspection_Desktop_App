using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightGearApp.interfaces
{
    interface IFindCorrelation
    {

        // returns the variance of X and Y
        float variance(List<float> x, int size);

        // returns the covariance of X and Y
        float cov(List<float> x, List<float> y, int size);

        // returns the Pearson correlation coefficient of X and Y
        float pearson(List<float> x, List<float> y, int size);

        // performs a linear regression and return s the line equation
        Line linear_reg(List<float> x, List<float> y, int size);

    }
}
