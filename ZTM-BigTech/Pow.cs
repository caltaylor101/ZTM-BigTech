using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTM_BigTech
{
    public class Pow
    {
        public double MyPow(double x, int n)
        {
            long power = n;
            if (power < 0)
            {
                power = -power;
                x = 1 / x;
            }

            double result = 1;
            while (power > 0) // x^13 = x^8 * x^4 * x^1   13 = (1101) ipower bipowerary
            {
                if (power % 2 == 1) result = result * x;
                x = x * x;
                power = power / 2;
            }

            return result;
        }
    }
}
