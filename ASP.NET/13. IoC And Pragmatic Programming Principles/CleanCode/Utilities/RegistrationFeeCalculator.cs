using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCode;

namespace CleanCode.Utilities
{
    public static class RegistrationFeeCalculator
    {
        public static int CalculateRegistrationFee(int? experience)
        {
            return experience switch
            {
                <= 1 => 500,
                <= 3 => 250,
                <= 5 => 100,
                <= 9 => 50,
                _ => 0
            };
        }
    }
}