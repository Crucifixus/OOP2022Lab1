using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2022Lab1
{
    internal class Decrementation : Function
    {
        public CellValue calculateValue(string operand)
        {
            CellValue cV = Cell.parseAndCalculate(operand);
            var lNumber = cV as NumberValue;

            if (lNumber != null)
            {
                return new NumberValue(lNumber.number - 1);
            }
            return cV;
        }
    }
}
