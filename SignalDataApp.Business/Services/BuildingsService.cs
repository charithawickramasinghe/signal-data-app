using Newtonsoft.Json;
using SignalDataApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Business.Services
{
    public class BuildingsService : IBuildingsService
    {
        public async Task<List<BuildingDto>> GetBuilding(string baseUrl, string accessToken)
        {
            //get buildings
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage getData = await client.PostAsync("Building/GetBuildings", null);

                DataTable dt = new DataTable();

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<BuildingDto>>(result);
                }
                else
                {
                    Console.WriteLine("Error colling web api");
                }
            }

            return null;

        }
    }
}
