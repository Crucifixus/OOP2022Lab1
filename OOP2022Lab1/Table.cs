using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2022Lab1
{
    public static class Table
    {
        static Table()
        {
            cells = new Cell[10, 10];
            for(int i = 0; i < 100; i++)
            {
                cells[i / 10, i % 10] = new Cell();
            }
        }
        private static Cell[,] cells;
        public static Cell getCell(uint row, uint column)
        {
            return cells[row,column];
        }
    }
}
