using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOFunctions
{
    [Serializable]
    public class PersonData
    {
        public string name { get; set; }
        public int age { get; set; }
        public PersonData(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public PersonData()
        {

        }
    }
}