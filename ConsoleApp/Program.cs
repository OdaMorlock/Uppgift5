using System;
using SharedLibrary.Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var device = new DeviceClientService("IOTString");

            Console.ReadKey();
        }
    }
}
