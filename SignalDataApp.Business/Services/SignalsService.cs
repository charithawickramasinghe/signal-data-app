﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public class SignalsService : ISignalsService
    {
        public async Task<List<SignalDto>> GetSignal(int buildingId, string baseUrl, string accessToken)
        {
            //get buildings
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                client.BaseAddress = new Uri(baseUrl);

                var json = JsonConvert.SerializeObject(new { BuildingId = buildingId });

                HttpResponseMessage getData = await client.PostAsync("Signal/GetSignals", new StringContent(json, Encoding.UTF8, "application/json"));


                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<SignalDto>>(result);
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
