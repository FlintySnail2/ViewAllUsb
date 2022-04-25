using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewAllUsb
{
    class USBDeviceInfo
    {
        #region Field Variables

        public string DeviceID { get; private set; }
        public string PnpDeviceID { get; private set; }
        public string Description { get; private set; }

        #endregion Field Variables

        #region Constructor
        public USBDeviceInfo(string deviceID, string pnpDeviceInfo, string description)
        {
            DeviceID = deviceID;
            PnpDeviceID = pnpDeviceInfo;
            Description = description;
        }

        #endregion Constructor
    }
}
