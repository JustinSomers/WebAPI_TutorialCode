using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PortfolioWebApi.Interfaces;

namespace PortfolioWebApi.Models
{
    public class AWSConnections: IAWSConnections
    {
        private readonly IConfiguration configuration;
        public AWSConnections(IConfiguration config)
        {
            configuration = config;

        }
        public string GetRDSConnectionString()
        {
            
            var section = configuration.GetSection("AWS_Strings");
            
            string dbname = section["RDS_DB_NAME"];
            if (string.IsNullOrEmpty(dbname)) return null;

            string username = section["RDS_USERNAME"];
            string password = section["RDS_PASSWORD"];
            string hostname = section["RDS_HOSTNAME"];
            string port = section["PORT"];
            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}
