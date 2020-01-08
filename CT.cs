/**
* @author   Troller Fabian
* @date      2019-04-08
* @brief    Class for container
* @file     CT.cs
* @version  1.0.0.0
*/

using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net;
using System.Threading;

namespace ClientProxmox
{
    public class CT : VPS
    {
        #region Constantes
        private const string DEFAULT_PASSWORD_CT = "";
        #endregion

        #region Variables
        #endregion

        #region Properties

        /// <summary>
        /// For privileged conteneur
        /// </summary>
        private bool Privileged { get; set; }

        /// <summary>
        /// Password of conteneur
        /// </summary>
        public string Password { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Ctor for container on Proxmox server
        /// </summary>
        /// <param name="data">The JToken data array from the WebRequest</param>
        public CT(string node, JToken data)
        {

            this.Node = node;
            this.Name = data[SharedObject.DEFAULT_DATA_JSON_NAME].ToString();
            this.Vmid = Convert.ToUInt32(data[SharedObject.DEFAULT_DATA_JSON_VMID]);
            this.Cpus = Convert.ToUInt32(data[SharedObject.DEFAULT_DATA_JSON_CPU]);
            this.Ram = Convert.ToDouble(data[SharedObject.DEFAULT_DATA_JSON_MEMORYMAX]) / GIB;
            this.Disk = Convert.ToDouble(data[SharedObject.DEFAULT_DATA_JSON_DISKMAX]) / GB;
            this.Uptime = Convert.ToDouble(data[SharedObject.DEFAULT_DATA_JSON_UPTIME]);
            this.Type = data[SharedObject.DEFAULT_DATA_JSON_TYPE]?.ToString() ?? VPS.TYPE.QEMU;
            try
            {
                // Try to get data from server throw exception if data is not founded
                this.Os = HttpToolBox.WebResponseToJObject(SharedObject.Client.Get(this.Node, this.Type,
                $"{this.Vmid}/config"))[SharedObject.DEFAULT_DATA_JSON][SharedObject.DEFAULT_DATA_JSON_OSTYPE]?.ToString() ?? string.Empty;

            }
            catch (WebException)
            {
                this.Os = string.Empty;
            }
            this.Status = data[SharedObject.DEFAULT_DATA_JSON_STATUS].ToString();

        }


        /// <summary>
        /// Ctor for construct CT with param
        /// </summary>
        /// <param name="pname">The name of CT</param>
        /// <param name="ppass">The password for CT</param>
        /// <param name="ptype">The type is LXC</param>
        /// <param name="pos">The os for the CT</param>
        /// <param name="pvmid">The vmid</param>
        /// <param name="pnode">The node where is the CT</param>
        /// <param name="pcpu">The cores of CPU</param>
        /// <param name="pram">The number of RAM</param>
        /// <param name="pdisk">The size of disk</param>
        public CT(string pname, string ptype, string pos, string pvmid, string pnode, uint pcpu, double pram, double pdisk, string ppass = DEFAULT_PASSWORD_CT, bool privileged = false)
        {
            this.Name = pname;
            this.Password = ppass;
            this.Type = ptype;
            this.Os = pos;
            this.Vmid = uint.Parse(pvmid);
            this.Node = pnode;
            this.Cpus = pcpu;
            this.Ram = pram;
            this.Disk = pdisk;
            this.Privileged = privileged;
        }


        /// <summary>
        /// Create CT object with ViewBags object
        /// </summary>
        /// <param name="viewBag"></param>
        public CT(ViewBags viewBag) : this(viewBag.Name, viewBag.Type, viewBag.Os, viewBag.Vmid.ToString(), viewBag.Node, viewBag.Cpus, viewBag.Ram, viewBag.Disk)
        {
            // Nothing here
        }
        #endregion

        #region Methods Public
        /// <summary>
        /// Create new CT
        /// </summary>
        public override WebResponse Create()
        {
            return SharedObject.Client.CreateNewVPS(this.Node, this.Type, this.Os, this.Vmid.ToString(),
                this.Name, this.Cpus, this.Ram, this.Disk, this.Password, this.Privileged);
        }


        /// <summary>
        /// Modify VM with the new value
        /// </summary>
        /// <param name="name">The name to set</param>
        /// <param name="type">The type is QEMU</param>
        /// <param name="os">The os of VM</param>
        /// <param name="vmid">The vmid identifier</param>
        /// <param name="node">The node where is the VM</param>
        /// <param name="cpu">The CPU cores to set</param>
        /// <param name="ram">The number of RAM allowed</param>
        /// <param name="disk">The disk allowed to set</param>
        public override WebResponse Modifiy(string name, string type, string os, string vmid, string node, uint cpu, double ram, double disk)
        {
            return SharedObject.Client.ModifyVPSPut(this.Node, this.Type, this.Vmid.ToString(), name, cpu, ram);
        }


        /// <summary>
        /// Resize LXC disk
        /// </summary>
        /// <param name="sizeDisk">The new size disk</param>
        /// <returns>Return the WebResponse</returns>
        public WebResponse Resize(string sizeDisk)
        {
            return SharedObject.Client.ResizeDisk(this.Node, this.Type, this.Vmid.ToString(), sizeDisk);
        }


        /// <summary>
        /// Shutdown the CT
        /// </summary>
        public override WebResponse Shutdown()
        {
            return SharedObject.Client.PostFromCookieCSRF(this.Node, this.Type, this.Vmid.ToString(), VPS.ACTION.STOP_CT);
        }


        /// <summary>
        /// Start the CT
        /// </summary>
        public override WebResponse Startup()
        {
            return SharedObject.Client.PostFromCookieCSRF(this.Node, this.Type, this.Vmid.ToString(), VPS.ACTION.START);
        }


        /// <summary>
        /// Reboot the CT
        /// </summary>
        public override WebResponse Reboot()
        {
            Shutdown().Dispose();
            Thread.Sleep(5000);
            return Startup();
        }


        /// <summary>
        /// Delete the Ct
        /// </summary>
        public override WebResponse Delete()
        {
            return SharedObject.Client.DeleteVmid(this.Node, this.Type, this.Vmid.ToString());
        }


        /// <summary>
        /// Draw CT to form
        /// </summary>
        public override Image Draw()
        {
            return Properties.Resources.Linux_Containers_logo;
        }
        #endregion

    }
}
