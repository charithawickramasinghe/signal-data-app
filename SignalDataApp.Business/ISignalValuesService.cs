using SignalDataApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Business
{
    public interface ISignalValuesService
    {
        Task<List<SignalValueDto>> GetSignalValue(int buildingId, string baseUrl, string accessToken);
    }
}
