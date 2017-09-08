using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOTextFiles
{
    class Program
    {
      

        static void Main()
        {
            STable sTable = new STable();
            IOSettings io = new IOSettings(sTable);

           

            if(io.Open())                 //io.Save())
            {
                Console.WriteLine("Таблицата е прочетена успешно.");
            }
            else
            {
                Console.WriteLine("Таблицата НЕ е прочетена  успешно.");
            }

            Console.WriteLine(sTable.stable[2]);
        }
    }
}
