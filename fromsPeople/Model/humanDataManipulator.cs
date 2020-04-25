using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace fromsPeople.Model
{
    class humanDataManipulator
    {
        private List<Human> myPeople = new List<Human>();

        public void AddHuman(string name, string surname, int age)
        {
            myPeople.Add(new Human(name, surname, age));
        }

        public void editHuman(int index, string name, string surname, int age)
        {
            myPeople[index].editHuman(name, surname, age);
        }

        public string getName(int index) { return myPeople[index].getName(); }
        public string getSurname(int index) { return myPeople[index].getSurname(); }
        public int getAge(int index) { return myPeople[index].getAge(); }

        public void deleteHuman(int index)
        {
            myPeople.RemoveAt(index);
        }

        public string[] getPeople()
        {
            string[] people = new string[myPeople.Count];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = myPeople[i].ToString();
            }
            return people;
        }

        private string fileName = "saveFile.xml";
        public void loadFromFile()
        {
            int counter = 0;
            string name = null;
            string surname = null;
            int age = 25;
            XmlTextReader reader = new XmlTextReader(fileName);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Text:
                        {
                            if (counter == 0) name = reader.Value;
                            else if (counter == 1) surname = reader.Value;
                            else if (counter == 2) age = int.Parse(reader.Value);
                            counter++;
                        }
                        break;
                }
                if (counter == 3)
                {
                    name = name.Replace(Environment.NewLine, "");
                    surname = surname.Replace(Environment.NewLine, "");
                    myPeople.Add(new Human(name, surname, age));
                    counter = 0;
                }
            }
            reader.Close();
        }

        public void saveToFile()
        {
            StreamWriter stream = new StreamWriter(fileName);
            stream.WriteLine("<humanList>");
            foreach (var item in myPeople)
            {
                stream.WriteLine("<human>");
                stream.WriteLine("<name>");
                stream.WriteLine(item.getName());
                stream.WriteLine("</name>");
                stream.WriteLine("<surname>");
                stream.WriteLine(item.getSurname());
                stream.WriteLine("</surname>");
                stream.WriteLine("<age>");
                stream.WriteLine(item.getAge().ToString());
                stream.WriteLine("</age>");
                stream.WriteLine("</human>");

            }



            stream.WriteLine("</humanList>");
            stream.Close();
        }
    }
}
