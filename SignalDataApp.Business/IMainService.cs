using SignalDataApp.Common.DTOs;
using SignalDataApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Business
{
    public interface IMainService
    {
        Task<List<Building>> GetBuildingSignalData(string accessToken);
    }
}
