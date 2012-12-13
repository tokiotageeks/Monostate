namespace MonoState.Test
{
    public class ClaseNegocio
    {
        private readonly IConfiguration configuration;

        public ClaseNegocio(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetActiveUserName()
        {
            return configuration.UserName;
        }
    }
}