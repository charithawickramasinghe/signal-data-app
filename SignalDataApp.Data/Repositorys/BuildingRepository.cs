using SignalDataApp.Common.DTOs;
using SignalDataApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Data.Repositorys
{
    
    public class BuildingRepository : IBuildingRepository
    {
        SignalDataDBContext signalDataDBContext;
        public BuildingRepository()
        {
            signalDataDBContext = new SignalDataDBContext();
        }

        public async Task<List<Building>> AddBuilding(List<Building> building)
        {
            //await signalDataDBContext.AddRangeAsync(building);
            //foreach (var bld in building)
            //{
            //    signalDataDBContext.Entry(bld).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            //}
            //await signalDataDBContext.SaveChangesAsync();
            return building;
        }
    }
}
