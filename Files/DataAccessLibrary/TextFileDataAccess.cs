using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class TextFileDataAccess
    {
        public List<ContactModel> ReadAllRecords(string textFile)
        {
            if (File.Exists(textFile) == false)
            {
                return new List<ContactModel>();
            }
            
            List<ContactModel> output = new List<ContactModel>();

            List<string> lines = File.ReadAllLines(textFile).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string[] entries = lines[i].Split(',');

                ContactModel c = new ContactModel();

                c.FirstName = entries[0];
                c.LastName = entries[1];
                c.PhoneNumbers = entries[2].Split(';').ToList();
                c.EmailAddresses = entries[3].Split(';').ToList();

                output.Add(c);
            }

            return output;
        }

        public void WriteAllRecords(List<ContactModel> contacts, string textFile)
        {
            List<string> lines = new List<string>();

            foreach (var c in contacts)
            {
                lines.Add($"{ c.FirstName },{ c.LastName },{ string.Join(";", c.PhoneNumbers) },{ string.Join(";", c.EmailAddresses) }");
            }

            File.WriteAllLines(textFile, lines);
        }   
    }
}
