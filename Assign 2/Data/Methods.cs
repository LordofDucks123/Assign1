using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http;
using Models;
using FileData;
using Microsoft.AspNetCore.Components;
using System;

namespace Assign2.Data
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

        public async Task<Adult> AddAdult(Adult adult)
        {
            adults.Add(adult);
            WriteAdultFile();
            return adult;
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


        public async Task<Adult> UpdateAsync(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            toUpdate.FirstName = adult.FirstName;
            WriteAdultFile();
            return toUpdate;
        }

        public async Task RemoveAdult(int adultId)
        {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            WriteAdultFile();
        }
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            using HttpClient client = new HttpClient(); HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:50001");

            if (!responseMessage.IsSuccessStatusCode) throw new Exception(@"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            return adults;
        }
    }
    }

