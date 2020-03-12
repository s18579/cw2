using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var lines = File.ReadLines(args[0]);
                var today = DateTime.Now;
                HashSet<student> students = new HashSet<student>(new OwnComparator());
                StreamWriter writer = new StreamWriter(@"log.txt");

                //cz.1 tworzenie HashSet i uzupelnianie nim danymi z pliku
                foreach (var line in lines)
                {
                    string[] student = line.Split(',');
                    if (student.Length == 9)
                    {
                        if (!Array.Exists(student, ele => ele == ""))
                        {
                            students.Add(new student
                            {
                                fname = student[0],
                                lname = Regex.Replace(student[1], "[0-9]", ""),
                                name = student[2],
                                mode = student[3],
                                indexNumber = "s" + student[4],
                                birthdate = student[5],
                                email = "s" + student[4] + @"@pjwstk.edu.pl",
                                mothersname = student[7],
                                fathersname = student[8]
                            });
                        }
                        else writer.WriteLine("Student o id: s" + student[4] + " ma puste pole");
                    }
                    else writer.WriteLine("Student o id: s" + student[4] + " ma nie poprawna ilosc elementow");
                }
                writer.Close();

                //cz.2 liczenie ilosci danych typow studiow
                Dictionary<string, int> count = new Dictionary<string, int>(); // oblicza wystepowanie kazdych z typow studiow
                foreach (var student in students)
                {
                    if (!count.ContainsKey(student.name)) count.Add(student.name, 1);
                    else count[student.name]++;
                }

                //cz.3 konwersja na XML
                if (args[2].Equals("xml"))
                {
                    XDocument doc = new XDocument(new XElement("uczelnia",
                        new XAttribute("createdAt", today),
                        new XAttribute("author", "Mateusz Bednarek"),
                        new XElement("studenci",
                            from student in students
                            select new XElement("student",
                            new XAttribute("indexNumber", student.indexNumber),
                            new XElement("fname", student.fname),
                            new XElement("lname", student.lname),
                            new XElement("birthdate", student.birthdate),
                            new XElement("email", student.email),
                            new XElement("mothersName", student.mothersname),
                            new XElement("fathersName", student.fathersname),
                            new XElement("studies",
                                new XElement("name", student.name),
                                new XElement("mode", student.mode)
                       ))),
                        new XElement("activeStudies",
                            from c in count
                            select new XElement("studies",
                                new XAttribute("name", c.Key),
                                new XAttribute("numberOfStudents", c.Value)
                                )
                        )));
                    doc.Save(args[1]);
                }
                else if (args[2].Equals("json")) Console.WriteLine("Jeszcze nie zaimplementowany JSON"); // TODO konwersja na json
                else Console.WriteLine("Wpisany zostal zly typ");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Podana scieszka jest niepoprawna");
                throw;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Plik nazwa nie istnieje");
                throw;
            }
        }
    }
}