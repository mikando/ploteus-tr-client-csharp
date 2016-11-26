using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PloteusTR.Client;
using Ploteus.TR.Client.Tests.Properties;

namespace Ploteus.TR.Client.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public void Upload_LearningOpportunities_Xml()
        {
            var client = getClient();
            var response = client.uploadLearningOpportunitiesXml(Resources.lo_full_sample);
            response.Wait();

            Assert.IsNotNull(response.Result.RequestId);
        }

        [TestMethod]
        public void Upload_Qualifications_Xml()
        {
            var client = getClient();
            var response = client.uploadQualificationsXml(Resources.qual_full_sample_xml);
            response.Wait();

            Assert.IsNotNull(response.Result.RequestId);
        }

        private PloteusWebClient getClient()
        {
            return new PloteusWebClient("CHANGE_WITH_YOUR_USERNAME", "CHANGE_WITH_YOUR_PASSWORD");
        }
    }
}
