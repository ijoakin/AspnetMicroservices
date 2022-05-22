using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class Practice
    {

        public void test()
        {
            int[] myArr = new int[500];

            for(int i = 0; i<500; i++)
            {
                myArr[i] = new Random().Next(1,500);
            }

            for (int i = 0; i < myArr.Length; i++)
            {
                Console.Write($"{myArr[i]},");
            }
            Console.WriteLine($"---------------------------------------------------------------------------------------------------------");

            //bubble sort
            for (int i = 0; i < myArr.Length; i++)
            {
                for (int j = 0; j < myArr.Length - 1; j++)
                {
                    if (myArr[j] > myArr[j+1])
                    {
                        int temp = myArr[j+1];
                        myArr[j+1] = myArr[j];
                        myArr[j] = temp;
                    }
                }
            }

            for (int i = 0; i < myArr.Length; i++)
            {
                Console.Write($"{myArr[i]},");
            }

        }

    }
}
