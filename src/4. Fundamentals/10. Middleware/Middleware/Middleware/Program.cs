#define Hello // or Chain or Map or MapWhen or MultiSeg or Culture or CultureMiddleware

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)

#if Hello
                .UseStartup<StartupHello>();
#endif

#if Chain
                .UseStartup<StartupChain>();
#endif

#if Map
                .UseStartup<StartupMap>();
#endif

#if MapWhen
                .UseStartup<StartupMapWhen>();
#endif

#if MultiSeg
                .UseStartup<StartupMultiSeg>();
#endif

#if Culture
                .UseStartup<StartupCulture>();
#endif

#if CultureMiddleware
                .UseStartup<StartupCultureMiddleware>();
#endif
    }
}
