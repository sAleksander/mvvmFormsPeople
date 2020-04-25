using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fromsPeople.Model
{
    class Human
    {
        string name;
        string surname;
        int age;

        public Human(string name, string surname, int age)
        {
            editHuman(name, surname, age);
        }

        public void editHuman(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public string getName() { return this.name; } 
        public string getSurname() { return this.surname; }
        public int getAge() { return this.age; }

        public override string ToString()
        {
            return $"{name}, {surname}, lat:{age} ";
        }

    }
}
