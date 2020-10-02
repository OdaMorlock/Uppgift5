using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace SharedLibrary.Services
{
    public class DeviceClientService
    {
        private DeviceClient _deviceClient;
        private int _interval = 10;

        public DeviceClientService(string connectionstring)
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(connectionstring, TransportType.Mqtt);
            _deviceClient.SetMethodHandlerAsync("Setinterval", SetTelemetryIntervalAsync, null).GetAwaiter();
        }

        public async Task<MethodResponse> SetTelemetryIntervalAsync(MethodRequest methodRequest, object userContext)
        {
            SetInterval(Convert.ToInt32(methodRequest.DataAsJson));
            return await Task.FromResult(new MethodResponse(Encoding.UTF8.GetBytes(methodRequest.DataAsJson), 200));
        }


        public bool SetInterval(int interval)
        {
            try
            {
                _interval = interval;
                return true;
            }
            catch 
            {

                return false;
            }
        }


    }
}
