using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016.Tests
{
    class Test1
    {
        Person p1 = new Person("John", "Doe");
            p1.Name = "New name John";

            List<string> strings = new List<string>();

            int[] a = { 1, 2, 3 };

            for (var i = 0; i < a.Count(); i++)
            {
                Console.Write(a[i] + ", ");
                strings.Add($"broj {a[i]}");
            }

            strings.Add("Rucno dodat broj 4");

            Console.WriteLine(String.Format("My name is: {0}, and my last name is: {1}", p1.Name, p1.SurName));
            Console.ReadLine();
    }
}


