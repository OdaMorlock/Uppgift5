using System;
using Xunit;
using Microsoft.Azure.Devices.Client;
using SharedLibrary.Services;
namespace IntervalTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData ("ConsoleApp", "SetInterval", "10", "200") ]
        [InlineData ("ConsoleApp", "GetInterval", "15", "501") ]
        public void Test1(string targetDevice, string methodName, string payload, string expected)
        {
            var service = new DeviceClientService("IOTHub");
            var response = service.InvokeMethodAsync(targetDevice, methodName, payload);

            Assert.Equal(expected, response.Result.Status.ToString());
        }
    }
}
