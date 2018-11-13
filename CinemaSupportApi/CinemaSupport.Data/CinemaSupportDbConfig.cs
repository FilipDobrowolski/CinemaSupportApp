using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Data
{
    public class CinemaSupportDbConfig : DbConfiguration
    {
        public CinemaSupportDbConfig()
        {
            //define configuration
            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
            var t = ConfigurationManager.ConnectionStrings["CinemaSupportContext"].ConnectionString;
            SetDefaultConnectionFactory(new SqlConnectionFactory(ConfigurationManager.ConnectionStrings["CinemaSupportContext"].ConnectionString));

        }
    }
}
