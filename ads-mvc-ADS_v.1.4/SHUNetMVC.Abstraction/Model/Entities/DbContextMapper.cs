using System;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using Wmo.Extension;

namespace SHUNetMVC.Abstraction.Model.Entities
{
    public class DbContextMapper : DB_PHE_ADSEntities
    {

        public DbContextMapper() : base(GetConnectionString("DB_PHE_ADSEntities"))
        {
        }

        public static string GetConnectionString(string connectionName)
        {
            try
            {
                string connectionStringRaw = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                string encrypted = new EntityConnectionStringBuilder(connectionStringRaw).ProviderConnectionString;
                string decrypted = decConn(encrypted);

                connectionStringRaw = connectionStringRaw.Replace(encrypted, decrypted);

                return connectionStringRaw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private static string decConn(string con)
        {
            Encryption Enc = Encryption.GetInstance;
            return Enc.Decrypt(con, Enc.Decrypt(ConfigurationManager.AppSettings["Con:Key"].ToString()));
        }

    }
}
