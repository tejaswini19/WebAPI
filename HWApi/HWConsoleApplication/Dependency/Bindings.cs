using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWConsoleApplication.Services;
using RestSharp;

namespace HWConsoleApplication.Dependency
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IRestClient>().To<RestClient>();
            Bind<IRestRequest>().To<RestRequest>();
            Bind<IHWService>().To<HWService>();
        }
    }
}
