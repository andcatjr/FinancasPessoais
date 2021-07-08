namespace FinancasPessoais.data.Configurations
{
    public static class DataBaseConfigurationParameters
    {
        public static string ConnectionString
        {
            get { return @"Server=Localhost\sqlexpress;Database=TesteFinanceiro;User Id=financeiro;Password=fin@anceiro;Trusted_Connection=True;"; }
        }
    }
}