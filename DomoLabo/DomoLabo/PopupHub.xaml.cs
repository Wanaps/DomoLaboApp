using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.BLE;
using Plugin.BLE.Abstractions;
using Plugin.BLE.Abstractions.Contracts;
using Plugin.BLE.Abstractions.Exceptions;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DomoLabo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    /*https://github.com/dotnet-bluetooth-le/dotnet-bluetooth-le*/
    public partial class PopupHub : Popup
    {
        public List<IDevice> deviceList;
        public PopupHub()
        {
            InitializeComponent();
            

            var ble = CrossBluetoothLE.Current;
            var adapter = CrossBluetoothLE.Current.Adapter;

            deviceList = new List<IDevice>();
            
            var state = ble.State;
            
            ble.StateChanged += (s, e) =>
            {
                Debug.WriteLine($"The bluetooth state changed to {e.NewState}");
            };
            
            adapter.DeviceDiscovered += (s,a) =>
            {
                if (a.Device.ToString() == null || a.Device.ToString().Split('|')[0] != "0df0032e")
                    return;
                
                Debug.WriteLine(a.Device.ToString());
                deviceList.Add(a.Device);

            };
            
            deviceList.Clear();
            ScanDevi(adapter);
            
        }

        async private void ScanDevi(IAdapter adapter)
        {
            await adapter.StartScanningForDevicesAsync();
            Debug.WriteLine(deviceList.Count());
            if(deviceList.Count() != 0) await Connect(adapter, deviceList[0]);
        }

        async private Task Connect(IAdapter adapter, IDevice device)
        {
            try 
            {
                var connectParameters = new ConnectParameters(false, true);
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    adapter.ConnectToDeviceAsync(device, connectParameters);
                });
            }
            catch(DeviceConnectionException ex)
            {
                Debug.WriteLine(ex);
            }
        }
        
    }
    
}