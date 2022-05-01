using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP_Operatorok
{
    class Action
    {
        public static List<Operator> Beolvas(string fileName)
        {
            List<Operator> operators = new List<Operator>();

            try
            {
                StreamReader be = new StreamReader(fileName);
                be.ReadLine();
                while (!be.EndOfStream)
                {
                    operators.Add(new Operator(be.ReadLine().Split(';')));
                }
                be.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return operators;
        }
    }
}
