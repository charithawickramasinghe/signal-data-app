using SignalDataApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Business
{
    public interface IBuildingsService
    {
        Task<List<BuildingDto>> GetBuilding(string baseUrl, string accessToken);
    }
}
