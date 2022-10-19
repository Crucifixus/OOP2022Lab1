using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2022Lab1
{
    public class CellValue
    {
        static public CellValue toNumberValue(string s)//from string
        {
            //if (number != null)
            //{
            //    return new NumberValue(number.number);
            //}
            //var sNumber = cv as StringValue;
            //if (sNumber != null)
            //{
            Int64 result;
            bool success = Int64.TryParse(s, out result);
            if (success)
            {
                if (result >= int.MinValue && result <= int.MaxValue)
                {
                    return new NumberValue((int)result);
                }
                else
                {
                    return new ErrorValue(ErrorValue.ErrorCode.OVERFLOW);
                }
            }
            else
            {
                return new ErrorValue(ErrorValue.ErrorCode.VALUE);
            }
            //}
        }
        static public CellValue toCellReference(string s)//from string
        {
            if (s.Length == 2)
            {
                int col = s[0] - 65;
                int row = s[1] - 48;
                if(col >= 0 && col < 10 && row >= 0 && row < 10)
                {
                    return Table.getCell((uint)row, (uint)col).calculate();
                }
            }
            return new ErrorValue(ErrorValue.ErrorCode.VALUE);
        }
    }
}
