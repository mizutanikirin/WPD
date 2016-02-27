﻿using System.Collections.ObjectModel;
using PortableDeviceApiLib;
using System;

namespace PortableDevices
{
    public class PortableDeviceCollection : Collection<PortableDevice>
    {
        private readonly PortableDeviceManager _deviceManager;

        public PortableDeviceCollection()
        {
            this._deviceManager = new PortableDeviceManager();
        }

        public void Refresh()
        {
            this._deviceManager.RefreshDeviceList();

            // Determine how many WPD devices are connected
            /*var deviceIds = new string[1];
            uint count = 1;
            this._deviceManager.GetDevices(ref deviceIds[0], ref count);

            // Retrieve the device id for each connected device
            deviceIds = new string[count];
            this._deviceManager.GetDevices(ref deviceIds[0], ref count);*/

            //Console.WriteLine("deviceIds0: " + deviceIds[0]);

            // change code *******
            var deviceIds = new string[2];
            deviceIds[0] = @"\\?\usb#vid_04b0&pid_0433#*******#{6ac27878-a6fa-4155-ba85-f98f491d4f33}";
            deviceIds[1] = @"\\?\usb#vid_04b0&pid_0433#*******#{6ac27878-a6fa-4155-ba85-f98f491d4f33}";
            Console.WriteLine("deviceIds: " + deviceIds[0]);

            foreach (var deviceId in deviceIds)
            {
                Add(new PortableDevice(deviceId));
            }
        }
    }
}