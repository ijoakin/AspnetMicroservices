using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public sealed class WorkingWithDelagates
    {

        struct Point
        {
            int x;
            int y;
        };

        public delegate int PerformCalculation(int x, int y);

        public int MethodForDelegate(int x, int y)
        {
            return x * y;
        }
        public void testing()
        {

            PerformCalculation perform = MethodForDelegate;

            var myValue = perform(1,2);

            PerformCalculation perform2 = (int x, int y) =>
            {
                return x + y;
            };

            perform2(1, 2);

            try
            {
                //int b = int.MaxValue;

                //var myChecked2 = b + 10;

                checked
                {
                    int a = int.MaxValue;
                    var myChecked = a + 10;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }
            

        }

    }
}
