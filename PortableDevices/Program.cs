using System;
using System.Threading.Tasks;

namespace PortableDevices
{
    class Program
    {

        static void Main()
        {
            var collection = new PortableDeviceCollection();

            collection.Refresh();
            
            Parallel.ForEach(collection, device => {
                device.Connect();
                Console.WriteLine(device.FriendlyName);

                var folder = device.GetContents();
                foreach (var item in folder.Files) {
                    DisplayObject(device, item);
                }

                device.Disconnect();
            });
        }

        public static void DisplayObject(PortableDevice device, PortableDeviceObject portableDeviceObject)
        {
            Console.WriteLine("device: " + device.FriendlyName + "   " + portableDeviceObject.Name);
            if (portableDeviceObject is PortableDeviceFolder)
            {
                DisplayFolderContents(device, (PortableDeviceFolder) portableDeviceObject);
            }
        }

        public static void DisplayFolderContents(PortableDevice device, PortableDeviceFolder folder)
        {
            foreach (var item in folder.Files)
            {
                Console.WriteLine(item.Name);
                if (item is PortableDeviceFile) {
                    device.DownloadFile((PortableDeviceFile)item, @"F:\t_tmp\");
                }

                if (item is PortableDeviceFile) {
                    device.DeleteFile((PortableDeviceFile)item);
                }

                if (item is PortableDeviceFolder)
                {
                    DisplayFolderContents(device, (PortableDeviceFolder) item);
                }
                
            }
        }
    }
}
