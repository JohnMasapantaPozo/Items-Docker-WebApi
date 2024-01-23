namespace WebApiDEMO.Config
{
    public class MongoDbConfig
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        // Admin user password spefified in Secrets Manager.
        public string Password { get; set; }

        public string ConnectionString { 
            get
            {
                // Upddated to receive username and password.
                return $"mongodb://{User}:{Password}@{Host}:{Port}";
            }
         }
    }
}