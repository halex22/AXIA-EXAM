
using AuthenticationLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLogic.Services
{
    public class PublicService : IPublicService
    {
        public string Health()
        {
            return $"Current date ${DateTime.Today.ToString("D")}";
        }
    }
}
