using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2022Lab1
{
    internal class Subtraction : Function
    {
        public CellValue calculateValue(string lOperand, string rOperand)
        {
            CellValue lCV = Cell.parseAndCalculate(lOperand);
            CellValue rCV = Cell.parseAndCalculate(rOperand);
            var lNumber = lCV as NumberValue;
            var rNumber = rCV as NumberValue;

            if (lNumber != null)
            {
                if (rNumber != null)
                {
                    return new NumberValue(lNumber.number - rNumber.number);
                }
                return rCV;
            }
            var lError = lCV as ErrorValue;
            if (rNumber != null && lError != null && lError.code == ErrorValue.ErrorCode.EMPTY)
            {
                return new NumberValue(-rNumber.number);
            }
            return lCV;
        }
    }
}
