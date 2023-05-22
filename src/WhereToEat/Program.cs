namespace WhereToEat
{
    // test 3riI71BXed5ebIOYwQntykeZuhjsdweEc9BxH5Jc26w= 
    //3riI71BXed5ebIOYwQntykeZuhjsdweEc9BxH5Jc26w=
    // 3riI71BXed5ebIOYwQntykeZuhjsdweEc9BxH5Jc26w=
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
    webBuilder.UseStartup<Startup>();
});
        }
    }
}
