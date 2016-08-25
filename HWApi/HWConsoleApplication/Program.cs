using HWConsoleApplication.Services;
using Ninject;
using RestSharp;
using System;
using System.Reflection;

namespace HWConsoleApplication
{
    class Program 
    {        
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var restClient = kernel.Get<IRestClient>();
            var restRequest = kernel.Get<IRestRequest>();
            var serviceReq = kernel.Get<IHWService>();

            var data = serviceReq.GetData();
            Console.Write(data.data);
        }
    }
}

