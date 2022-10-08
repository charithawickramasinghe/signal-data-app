using SignalDataApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Business
{
    public interface ISignalsService
    {
        Task<List<SignalDto>> GetSignal(int buildingId, string baseUrl, string accessToken);
    }
}
