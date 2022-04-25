using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//Add the following references
using System.Management;



namespace ViewAllUsb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
        }

        static List<USBDeviceInfo> GetUSBDevices()
        {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_USBHub"))
                collection = searcher.Get();



            foreach (var device in collection)
            {
                devices.Add(new USBDeviceInfo(
                    (string)device.GetPropertyValue("DeviceID"),
                    (string)device.GetPropertyValue("PnpDeviceID"),
                    (string)device.GetPropertyValue("Description")
                    ));
            }
            collection.Dispose();
            return devices;

        }
        public void DeviceID_Click(object sender, RoutedEventArgs e)
        {

            var usbDeviceId = GetUSBDevices();
            foreach (var usbDevice in usbDeviceId)
            {
                MessageBox.Text += "\n" + usbDevice.DeviceID ;
            }

            if (String.IsNullOrEmpty(MessageBox.Text))
            {

            }
            else
            {
                //IF messagebox contains a string disable buttons enable clear button.
                PNPDevice.IsEnabled = false;
                Description.IsEnabled = false;
                Clear.IsEnabled = true;
            }
        }

    

        private void PNPDevice_Click(object sender, RoutedEventArgs e)
        {

            var usbPnpId = GetUSBDevices();
            foreach (var PnpId in usbPnpId)
            {
                
                MessageBox.Text += "\n" + PnpId.PnpDeviceID;
            }

            if (String.IsNullOrEmpty(MessageBox.Text))
            {

            }
            else
            {
                DeviceID.IsEnabled = false;
                Description.IsEnabled = false;
                Clear.IsEnabled = true;
            }
        }

        private void Description_Click(object sender, RoutedEventArgs e)
        {

            

            var usbDesc = GetUSBDevices();
            foreach (var Description in usbDesc)
            {
                MessageBox.Text += "\n" + Description.Description;
            }

            if (String.IsNullOrEmpty(MessageBox.Text))
            {

            }
            else
            {
                DeviceID.IsEnabled = false;
                PNPDevice.IsEnabled = false;
                Clear.IsEnabled = true;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {

            

            if (String.IsNullOrEmpty(MessageBox.Text))
            {

            }
            else
            {

                MessageBox.Text = "";
                DeviceID.IsEnabled = true;
                PNPDevice.IsEnabled = true;
                Description.IsEnabled = true;
                Clear.IsEnabled = false;
            }
        }
    }
}
