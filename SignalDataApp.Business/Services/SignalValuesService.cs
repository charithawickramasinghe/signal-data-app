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
    public class SignalValuesService : ISignalValuesService
    {
        public async Task<List<SignalValueDto>> GetSignalValue(int buildingId, string baseUrl, string accessToken)
        {
            //get signal values.
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(baseUrl);

                var json = JsonConvert.SerializeObject(new { BuildingId = buildingId });

                HttpResponseMessage getData = await client.PostAsync("Signal/GetSignalValues", new StringContent(json, Encoding.UTF8, "application/json"));

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<SignalValueDto>>(result);
                }
                else
                {
                    Console.WriteLine("Error colling web api");
                }

                return null;
            }

        }
    }
}
