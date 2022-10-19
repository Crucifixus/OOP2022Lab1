using OOP2022Lab1.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP2022Lab1
{
    public class Cell
    {
        public string formula = "";
        public enum CalculationProgress {PENDING, IN_PROGRESS, DONE };
        public CalculationProgress state = CalculationProgress.PENDING;
        public CellValue value = new ErrorValue(ErrorValue.ErrorCode.EMPTY);
        public static CellValue parseAndCalculate(string proposed_formula)//recursive parser, gets called a lot
        {
            if (proposed_formula == "")
            {
                return new ErrorValue(ErrorValue.ErrorCode.EMPTY);
            }
            string left = "";
            string right = "";
            CellValue res;
            int correctScope = 0;
            int scopeStart = 0;
            int scopeEnd = proposed_formula.Length - 1;
            //(((((((((((((((((((((((((((((((())))))))))))))))))))))))))))))))
            while (proposed_formula[scopeStart] == '(' && proposed_formula[scopeEnd] == ')')
            {
                ++scopeStart;
                --scopeEnd;
            }
            //div()div()div()div()div()div()  mod()mod()mod()mod()mod()mod()
            if (scopeEnd - scopeStart >= 7)
            {
                //div()div()div()div()div()div()
                if (proposed_formula.Substring(scopeStart, 4) == "div(" && proposed_formula[scopeEnd] == ')')
                {
                    scopeStart += 4;
                    --scopeEnd;
                    for (int i = scopeStart; i < scopeEnd; i++)
                    {
                        if (proposed_formula[i] == ')')
                        {
                            ++correctScope;
                        }
                        if (correctScope == 0 && proposed_formula[i] == ',')
                        {
                            Division diV = new Division();
                            left = proposed_formula.Substring(scopeStart, i - scopeStart);
                            right = proposed_formula.Substring(i + 1, scopeEnd - i);
                            res = diV.calculateValue(left, right);
                            return res;
                        }
                        if (proposed_formula[i] == ')')
                        {
                            --correctScope;
                            if (correctScope < 0)
                            {
                                return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
                            }
                        }
                    }
                    if (correctScope > 0)
                    {
                        return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
                    }
                }
                //mod()mod()mod()mod()mod()mod()
                if (proposed_formula.Substring(scopeStart, 4) == "mod(" && proposed_formula[scopeEnd] == ')')
                {
                    scopeStart += 4;
                    --scopeEnd;
                    for (int i = scopeStart; i < scopeEnd; i++)
                    {
                        if (proposed_formula[i] == ')')
                        {
                            ++correctScope;
                        }
                        if (correctScope == 0 && proposed_formula[i] == ',')
                        {
                            Modulo mod = new Modulo();
                            left = proposed_formula.Substring(scopeStart, i - scopeStart);
                            right = proposed_formula.Substring(i + 1, scopeEnd - i);
                            res = mod.calculateValue(left, right);
                            return res;
                        }
                        if (proposed_formula[i] == ')')
                        {
                            --correctScope;
                            if (correctScope < 0)
                            {
                                return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
                            }
                        }
                    }
                    if (correctScope > 0)
                    {
                        return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
                    }
                }
            }
            //inc()inc()inc()inc()inc()inc()  dec()dec()dec()dec()dec()dec()
            if (scopeEnd - scopeStart >= 5)
            {
                //inc()inc()inc()inc()inc()inc()
                if (proposed_formula.Substring(scopeStart, 4) == "inc(" && proposed_formula[scopeEnd] == ')')
                {
                    scopeStart += 4;
                    --scopeEnd;
                    Incrementation inc = new Incrementation();
                    left = proposed_formula.Substring(scopeStart, scopeEnd - scopeStart + 1);
                    res = inc.calculateValue(left);
                    return res;
                }
                //dec()dec()dec()dec()dec()dec()
                if (proposed_formula.Substring(scopeStart, 4) == "dec(" && proposed_formula[scopeEnd] == ')')
                {
                    scopeStart += 4;
                    --scopeEnd;
                    Decrementation dec = new Decrementation();
                    left = proposed_formula.Substring(scopeStart, scopeEnd - scopeStart + 1);
                    res = dec.calculateValue(left);
                    return res;
                }
            }
            //++++++++++++++++++++++++++++++++--------------------------------
            for (int i = scopeStart; i < scopeEnd; i++)
            {
                if(proposed_formula[i] == ')')
                {
                    ++correctScope;
                }
                if (correctScope == 0) {
                    switch (proposed_formula[i])
                    {
                        case '+':
                            Addition add = new Addition();
                            left = proposed_formula.Substring(scopeStart, i - scopeStart);
                            right = proposed_formula.Substring(i + 1, scopeEnd - i);
                            res = add.calculateValue(left, right);
                            return res;
                        case '-':
                            Subtraction sub = new Subtraction();
                            left = proposed_formula.Substring(scopeStart, i - scopeStart);
                            right = proposed_formula.Substring(i + 1, scopeEnd - i);
                            res = sub.calculateValue(left, right);
                            return res;
                    }

                }
                if (proposed_formula[i] == ')')
                {
                    --correctScope;
                    if (correctScope < 0)
                    {
                        return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
                    }
                }    
            }
            if (correctScope > 0)
            {
                return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
            }
            //********************************////////////////////////////////
            for (int i = scopeStart; i < scopeEnd; i++)
            {
                if (proposed_formula[i] == ')')
                {
                    ++correctScope;
                }
                if (correctScope == 0)
                {
                    switch (proposed_formula[i])
                    {
                        case '*':
                            Multiplication mul = new Multiplication();
                            left = proposed_formula.Substring(scopeStart, i - scopeStart);
                            right = proposed_formula.Substring(i + 1, scopeEnd - i);
                            res = mul.calculateValue(left, right);
                            return res;
                        case '/':
                            Division div = new Division();
                            left = proposed_formula.Substring(scopeStart, i - scopeStart);
                            right = proposed_formula.Substring(i + 1, scopeEnd - i);
                            res = div.calculateValue(left, right);
                            return res;
                    }
                }
                if (proposed_formula[i] == ')')
                {
                    --correctScope;
                    if (correctScope < 0)
                    {
                        return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
                    }
                }
            }
            if (correctScope > 0)
            {
                return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
            }
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            for (int i = scopeStart; i < scopeEnd; i++)
            {
                if (proposed_formula[i] == ')')
                {
                    ++correctScope;
                }
                if (correctScope == 0 && proposed_formula[i] == '^')
                {
                    RaisingToPower pow = new RaisingToPower();
                    left = proposed_formula.Substring(scopeStart, i - scopeStart);
                    right = proposed_formula.Substring(i + 1, scopeEnd - i);
                    res = pow.calculateValue(left, right);
                    return res;
                }
                if (proposed_formula[i] == ')')
                {
                    --correctScope;
                    if (correctScope < 0)
                    {
                        return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
                    }
                }
            }
            if (correctScope > 0)
            {
                return new ErrorValue(ErrorValue.ErrorCode.PARENTHESES);
            }
            // To number, to cell reference or return an error;
            var num = CellValue.toNumberValue(proposed_formula.Substring(scopeStart, scopeEnd - scopeStart + 1));
            var error = num as ErrorValue;
            if (error == null)
            {
                return num;
            }
            if (error.code == ErrorValue.ErrorCode.OVERFLOW)
            {
                return error;
            }
            return CellValue.toCellReference(proposed_formula.Substring(scopeStart, scopeEnd - scopeStart + 1));
        }
        public CellValue calculate()//a function that is not recursive and is called once per table refresh and for every cell reference
        {
            if (state == CalculationProgress.DONE)
            {
                return value;
            }
            if (state == CalculationProgress.IN_PROGRESS)
            {
                return new ErrorValue(ErrorValue.ErrorCode.REF_CYCLE);
            }
            if (formula != "")
            {
                CellValue res;
                state = CalculationProgress.IN_PROGRESS;
                res = parseAndCalculate(formula);
                value = res;
            }
            state = CalculationProgress.DONE;
            return value;
        }
    }
}
