using SHUNetMVC.Abstraction.Repositories;
using SHUNetMVC.Infrastructure.Constant;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using Wmo.Extension;

namespace SHUNetMVC.Web.Providers
{
    public class ConnectionStringProvider : IConnectionProvider
    {
        public string GetConnectionString()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB_PHE_ADSEntities"].ConnectionString;
            string encrypted = new EntityConnectionStringBuilder(connectionString).ProviderConnectionString;

            string result = decConn(encrypted);
            return result;
        }

        //public string GetConnectionString()
        //{
        //    //string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
        //    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DB_PHE_ADSEntities"].ConnectionString;
        //    int pFrom = connectionString.IndexOf("\"") + 1;
        //    int pTo = connectionString.LastIndexOf("\"");

        //    string result = "";
        //    if (pFrom <= pTo)
        //    {
        //        result = connectionString.Substring(pFrom, pTo - pFrom);
        //    }
        //    return result;
        //}


        private static string decConn(string con)
        {
            Encryption Enc = Encryption.GetInstance;
            return Enc.Decrypt(con, Enc.Decrypt(AimanConstant.ConKey));
        }

    }
}