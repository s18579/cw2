using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Mati\Desktop\cw2\dane.csv";
            var lines = File.ReadLines(path);
            var today = DateTime.Now;
            HashSet<student> students = new HashSet<student>(new OwnComparator());
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
                    //else Console.WriteLine("Student o id: s" + student[4] + " ma puste pole");
                }
                //else Console.WriteLine("Student o id: s" + student[4] + " ma nie poprawna ilosc elementow");
            }
            XDocument doc = new XDocument(new XElement("uczelnia",
                new XAttribute("createdAt",today),
                new XAttribute("author","Mateusz Bednarek"),
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
               )))));
            doc.Save(@"C:\Users\Mati\Desktop\data.xml");
        }
    }
}