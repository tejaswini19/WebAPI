
using System.Collections.Generic;
using HWCommonModel.Models;
using HWConsoleApplication.Services;
using Moq;
using NUnit.Framework;
using RestSharp;

namespace HWApi.Tests
{
    [TestFixture]
    public class HelloWorldWebServiceUnitTests
    {
        private Mock<IRestClient> restClientMock;

        private Mock<IRestRequest> restRequestMock;

        private HWService helloWorldService;

        [OneTimeSetUp]
        public void InitTestSuite()
        {
            this.restClientMock = new Mock<IRestClient>();
            this.restRequestMock = new Mock<IRestRequest>();
            this.helloWorldService = new HWService(this.restClientMock.Object, this.restRequestMock.Object);
        }

        #region GetData Tests        
        [Test]
        public void UnitTestHWConsoleApplicationRunDataSuccess()
        {
            const string Data = "Hello World";
            var mockParameters = new Mock<List<Parameter>>();
            var mockRestResponse = new Mock<IRestResponse<HWData>>();
            var data = GetData(Data);

            this.restRequestMock.Setup(m => m.Parameters).Returns(mockParameters.Object);
            this.restClientMock.Setup(m => m.Execute<HWData>(It.IsAny<IRestRequest>())).Returns(mockRestResponse.Object);
            mockRestResponse.Setup(m => m.Data).Returns(data);

            var response = this.helloWorldService.GetData();

            Assert.NotNull(response);
            Assert.AreEqual(response.data, data.data);
        }


        [Test]
        public void UnitTestHWConsoleApplicationRunDataNullResponse()
        {
            const string Data = "Hello World";
            var mockParameters = new Mock<List<Parameter>>();
            var mockRestResponse = (IRestResponse<HWData>)null;
            var data = GetData(Data);


            this.restRequestMock.Setup(m => m.Parameters).Returns(mockParameters.Object);
            this.restClientMock.Setup(m => m.Execute<HWData>(It.IsAny<IRestRequest>())).Returns(mockRestResponse);

            var response = this.helloWorldService.GetData();
            Assert.IsNull(response);
        }


        [Test]
        public void UnitTestHelloWorldConsoleAppRunNormalDataNullData()
        {
            var mockParameters = new Mock<List<Parameter>>();
            var mockRestResponse = new Mock<IRestResponse<HWData>>();
            HWData data = null;

            this.restRequestMock.Setup(m => m.Parameters).Returns(mockParameters.Object);
            this.restClientMock.Setup(m => m.Execute<HWData>(It.IsAny<IRestRequest>())).Returns(mockRestResponse.Object);
            mockRestResponse.Setup(m => m.Data).Returns(data);

            var resp = this.helloWorldService.GetData();
            Assert.IsNull(resp);

        }
        #endregion

        #region Helper Methods
        private static HWData GetData(string data)
        {
            return new HWData { data = data };
        }
        #endregion
    }
}
