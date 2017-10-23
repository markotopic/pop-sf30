using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SF_30_2016
{
    class Person
    {
        string name = "";
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }

        }
        public string SurName { get; set; }

        public Person(string name, string surname)
        {
            Name = name;
            SurName = surname;
        }

    }
}
