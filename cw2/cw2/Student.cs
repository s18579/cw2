using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2
{
    public class student
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string name { get; set; }
        public string mode { get; set; }
        public string indexNumber { get; set; }
        public string birthdate { get; set; }
        public string email { get; set; }
        public string mothersname { get; set; }
        public string fathersname { get; set; }
        public override string ToString()
        {
            return "Index: " + indexNumber
                + "\nImie: " + fname
                + "\nNazwisko: " + lname 
                + "\nTyp Studiow: " + name
                + "\nTryb Studiow: " + mode
                + "\nData Urodzenia: " + birthdate
                + "\nMail: " + email
                + "\nImie Matki: " + mothersname
                + "\nImie Ojca: " + fathersname
                + "\n";
        }
    }
}