using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\s18579\Downloads\dane.csv";
            var lines = File.ReadLines(path);
            var today = DateTime.Now;
            HashSet<Student> students = new HashSet<Student>(new OwnComparator());
            foreach (var line in lines)
            {
                string[] student = line.Split(',');
                if (student.Length == 9)
                {
                    Regex re = new Regex(@"([a-zA-Z]+)(\d+)");
                    Match result = re.Match(student[1]);
                    string splitNazwisko = result.Groups[1].Value;
                    students.Add(new Student
                    {
                        Imie = student[0],
                        Nazwisko = splitNazwisko,
                        TypStudiow = student[2],
                        TrybStudiow = student[3],
                        Index = "s" + student[4],
                        DataUrodz = student[5],
                        Mail = student[6],
                        ImieMatki = student[7],
                        ImieOjca = student[8]
                    });
                }
            }
            foreach(var student in students)
            {
                Console.WriteLine(student.Imie + " " + student.Nazwisko + " " +student.Index);
            }
        }
    }
}
