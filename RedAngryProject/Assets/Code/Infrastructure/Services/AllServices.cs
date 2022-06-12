namespace Assets.Code.Infrastructure.Services
{
    public class AllServices 
    {
        private static AllServices _instance;
        public static AllServices Container => _instance ?? (_instance = new AllServices());


    }
}