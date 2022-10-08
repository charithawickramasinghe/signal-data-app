using SignalDataApp.Common.DTOs;
using SignalDataApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Data
{
    public interface IBuildingRepository
    {
        Task<List<Building>> AddBuilding(List<Building> building);
    }
}
