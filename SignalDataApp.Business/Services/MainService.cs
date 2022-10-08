using Microsoft.AspNetCore.Http;
using SignalDataApp.Common.DTOs;
using SignalDataApp.Data;
using SignalDataApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Business.Services
{
    public class MainService : IMainService
    {
        private readonly IBuildingsService buildingsService;
        private readonly ISignalsService signalsService;
        private readonly ISignalValuesService signalValuesService;
        private readonly IBuildingRepository buildingRepository;

        private readonly string baseUrl = "https://datastorage-fake-myrspoven.azurewebsites.net/";

        public MainService(IBuildingsService buildingsService, ISignalsService signalsService, ISignalValuesService signalValuesService, IBuildingRepository buildingRepository)
        {
            this.buildingsService = buildingsService;
            this.signalsService = signalsService;
            this.signalValuesService = signalValuesService;
            this.buildingRepository = buildingRepository;
        }

        public async Task<List<Building>> GetBuildingSignalData(string accessToken)
        {

            //call the GetBuildings api.
            var buildings = await buildingsService.GetBuilding(baseUrl, accessToken);
            var signals = new List<SignalDto>();
            //var signaValues = new List<SignalValueDto>();

            foreach (var bldng in buildings)
            {
                //call the GetSignals api.
                signals.AddRange( await signalsService.GetSignal(bldng.Id, baseUrl, accessToken));
                //call the GetSignalsValues api.
                //signaValues.AddRange(await signalValuesService.GetSignalValue(bldng.Id, baseUrl, accessToken));
            }

            var buildingEntities = new List<Building>();

            foreach (var building in buildings)
            {
                var signalValues = await signalValuesService.GetSignalValue(building.Id, baseUrl, accessToken);
                var build = new Building
                {
                    Id = building.Id,
                    Name = building.Name,
                    Signals = signals.Where(s => s.BuildingId == building.Id).Select(s =>
                    {
                        return new Signal
                        {
                            Id = s.Id,
                            BuildingId = s.BuildingId,
                            Name = s.Name,
                            SignalValues = signalValues.Where(sv => sv.SignalId == s.Id).Select(sv =>
                            {
                                return new SignalValue
                                {
                                    Id = sv.Id,
                                    SignalId = sv.SignalId,
                                    Value = sv.Value,
                                    DataUtc = sv.DataUtc,
                                    ReadUtc = sv.ReadUtc
                                };
                            }).ToList()
                        };
                    }).ToList()


                };
                buildingEntities.Add(build);
            }

            var result = await buildingRepository.AddBuilding(buildingEntities);

            return result;
        }
    }
}
