using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient;
using MarketClient.Utils;

namespace MarketClientTest
{
    [TestClass]
    public class UnitTest1
    {
        // fill those variable with our own data
        private const string Url = "http://ise172.ise.bgu.ac.il";
        private const string User = "user39";
        private const string PrivateKey = 
            "MIICXQIBAAKBgQDFVnV4cmYNmsxUxwmyZaiEQ8UP77yObHTxNlwDFmBAgS60svyrv8ogpSDCYtS11zBIUlZMgdiUmNblc1EzrhVvJgd7vAWD8d2hqK71FoifQYWP54gp5EAMsLSLKUIZNXDSuTD4xMwsCx/akU+nCMEiiuKBNKJFu0u38xY5V/fI7QIDAQABAoGBAIXTKD7SddrsC33CrRTKVAm+W7l+/wQnEPczwhpl5khYUvBAIZHnso+I7DpnA5F9qUSicdvYgqPjMnjQR1UgzW8tW6FvpVe0Y9d2B/ZfAkjaPdHX9MC8Q2omo3qUBSasN5ls7DyUbqdjqvOFsgtx1b/Y+Ym54Ggh8jMK0y1RuvMRAkEA0S7lNSQw/IlQoB+AiBU/IsMBH1hSkqGDBMq/vtjULnmtqGsnXlWQb83KmAhUTbyl1GCMyAcn4wNDzvbLv/WVgwJBAPGA4XsdGBqE1xIaM4URzQc+WjeMY8QmwsDe1+3tKNFuC8OrqJ184DUID9TvZSPvlHmJAzgtV2LDsK9Xk4krTM8CQHQecCYbvQWyxAre8d6YzL9jOJBJ2yyCc9SJJ/+tJbvW18uSD/yRyugFeN0EYqf0fKl0HzI6pq2h9lZBMcGRdjkCQQCUpD+j9+9K+zIouSm2oJMx/yWmBOmu5DCAZ2g9z/eMl4/0GiaI8EBLQ7AC3mnA6YfYGgV6QSYE6u9HrL5o8davAkAzF9bt78+GsxoR3VPQlh7gtQvlVirNyxArbj7bPCS2WfMJyweydEvMfN4DgcoK8an3F7wkuM9KHNcXiWVYbx1G";



        [TestMethod]
        public void TestSimpleHTTPPost()
        {
            // Attantion!, this code is not good practice! this was made for the sole purpose of being an example.
            // A real good code, should use defined classes and and not hardcoded values!
            SimpleHTTPClient client = new SimpleHTTPClient();
            var request = new{
                type = "queryUser",
            };
            string response = client.SendPostRequest(Url,User,SimpleCtyptoLibrary.CreateToken(User,PrivateKey), request);
            Trace.Write($"Server response is: {response}");
        }

        [TestMethod]
        public void TestObjectBasedHTTPPost()
        {
            // This test query a diffrent site (not the MarketServer)! it's only for demostration.
            // this site doenst accept authentication, it only returns objects.
            string url = "http://ip.jsontest.com/";
            SimpleHTTPClient client = new SimpleHTTPClient();
            IpAddress ip = new IpAddress {Ip = "8.8.8.8"};
            IpAddress response = client.SendPostRequest<IpAddress,IpAddress>(url, null, null, ip);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Ip);
            Trace.Write($"Server response is: {response.Ip}");
        }

        private class IpAddress
        {
            public string Ip { get; set; }
        }
    }
}
