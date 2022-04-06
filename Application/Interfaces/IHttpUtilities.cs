using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHttpUtilities
    {
        public string ExecuteHttpRequest(string endpoint, string requestBody = null, Dictionary<string, string> headers = null);
    }
}
