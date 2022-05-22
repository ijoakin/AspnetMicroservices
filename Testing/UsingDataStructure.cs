using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class UsingDataStructure
    {
        public static void testCustomList()
        {

            var myList = new CustomList<int>();

            for (int i = 0; i < 10; i++)
            {
                myList.Add(i);
            }
            
            Console.WriteLine(myList.FindElement(30));

            myList.Start();
            do
            {
                Console.WriteLine(myList.GetValue());
            }
            while (myList.Next());
 

            //Console.WriteLine(myList.GetValue());
        }
    }
}
