using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HWCommonModel.Models;
using System.Net.Http;
using RestSharp;
using System.Configuration;

namespace HWConsoleApplication.Services
{
    public class HWService : IHWService
    {
        private readonly IRestClient restClient;
        private readonly IRestRequest restRequest;
        public HWService(
            IRestClient restClient,
            IRestRequest restRequest)
        {
            this.restClient = restClient;
            this.restRequest = restRequest;
        }
        public HWData GetData()
        {
            HWData hwData = null;
            var baseUrl = ConfigurationManager.AppSettings.Get("HWApiUrl");
            var urlBaseurl = new Uri(baseUrl);

            this.restClient.BaseUrl = urlBaseurl;           
            this.restRequest.Resource = "HW";
            this.restRequest.Method = Method.GET;            
            this.restRequest.Parameters.Clear();

            var hwDataResponse = this.restClient.Execute<HWData>(this.restRequest);

            if (hwDataResponse != null)
            {
                if (hwDataResponse.Data != null)
                {
                    hwData = hwDataResponse.Data;
                }                
            }
            return hwData;
        }
    }
}
