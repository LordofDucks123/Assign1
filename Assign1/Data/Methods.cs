using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;
using FileData;
using Microsoft.AspNetCore.Components;

namespace Assign1.Data
{
    public class Methods : IAdult
    {
        private IList<Adult> adults;
        private FileContext fileContext;
        public string AdultFile = "adults.json";

        public Methods()
        {
            if (!File.Exists(AdultFile))
            {

                WriteAdultFile();
            }
            else
            {
                string content = File.ReadAllText(AdultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }

        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        public void AddAdult(Adult adult)
        {
            adults.Add(adult);
            WriteAdultFile();
        }


        private void WriteAdultFile()
        {
            string todoAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(AdultFile, todoAsJson);
        }

        private void WriteAdultsToFile()
        {
            string adultasJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(AdultFile, adultasJson);
            fileContext.SaveChanges();
        }


        public Adult Get(int id)
        {
            return adults.FirstOrDefault(t => t.Id == id);
        }
        public void Update(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            WriteAdultFile();
        }

    }
}
