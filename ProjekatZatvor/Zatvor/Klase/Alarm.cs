using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Zatvor.ViewModel;
using Zatvor.DataSource;
using Zatvor_pokusaj2.Klase;
using Microsoft.Maker.RemoteWiring;
using Microsoft.Maker.Serial;
using System.Threading.Tasks;

/*
NuGet package: Install-Package Windows-Remote-Arduino
Package.appxmanifest: 
        <Capability Name="privateNetworkClientServer"/>
        <Capability Name="internetClientServer"/>
        <DeviceCapability Name="serialcommunication">
            <Device Id="any">
                <Function Type="name:serialPort"/>
            </Device>
        </DeviceCapability>
*/

namespace Zatvor.Forme
{
    public class Alarm
    {
        IStream connction;
        private RemoteDevice _arduino;
        public Alarm()
        {
            var usb = new UsbSerial("VID_1A86", "PID_7523");
            _arduino = new RemoteDevice(usb);
            _arduino.DeviceReady += Setup;
            usb.begin(57600, SerialConfig.SERIAL_8N2);
        }
        public bool IsOn { get; private set; } = true;
        public bool t = true;

        public async void Toggle()
        {
            int delaymil = 250;

            while (t)
            {
                _arduino.digitalWrite(13, PinState.HIGH);
                await Task.Delay(delaymil);

                _arduino.digitalWrite(13, PinState.LOW);
                await Task.Delay(delaymil);

            }

        }
        private void Setup()
        {
            _arduino.pinMode(13, PinMode.OUTPUT);
        }
    }
}
