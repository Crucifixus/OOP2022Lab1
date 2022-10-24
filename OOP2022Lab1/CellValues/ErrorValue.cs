using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2022Lab1
{
    public class ErrorValue : CellValue
    {
        public enum ErrorCode {TYPE, DIV0, VALUE, PARENTHESES, REF_CYCLE, OVERFLOW, CYRILLIC, EMPTY}; 
        //Value is when the value is not something allowed, like random letters etc. everything else is self-explanatory.
        public ErrorValue(ErrorCode errCode)
        {
            code = errCode;
        }
        public ErrorCode code;
    }
}
