using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalDataApp.Business
{
    public interface ITokenService
    {
        Task<string> GetToken();
    }
}
