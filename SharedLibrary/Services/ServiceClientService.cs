using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;


namespace SharedLibrary.Services
{
    class ServiceClientService
    {

        private ServiceClient serviceClient;

        public ServiceClientService(string connectionstring)
        {
            serviceClient = ServiceClient.CreateFromConnectionString(connectionstring);
        }

        public async Task<CloudToDeviceMethod> InvokeMethodAsync(string targetDevice, string methodName, string payload)
        {
            var methodInvocation = new CloudToDeviceMethod(methodName);
            methodInvocation.SetPayloadJson(payload);

            var respone = await serviceClient.InvokeDeviceMethodAsync(targetDevice, methodInvocation);
            return respone;
        }

    }
}
