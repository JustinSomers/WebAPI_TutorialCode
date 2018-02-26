using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebApi.Interfaces
{
    interface IAWSConnections
    {
        string GetRDSConnectionString();
    }
}
