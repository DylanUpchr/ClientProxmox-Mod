/**
* @author   Troller Fabian
* @date      2019-04-08
* @brief    Class for Vm
* @file     VM.cs
* @version  1.0.0.0
*/

using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Net;
using System.Threading;

namespace ClientProxmox
{
    public class VM : VPS
    {

        #region Constructors
        /// <summary>
        /// Ctor for VM on server Proxmox
        /// </summary>
        /// <param name="data">The JToken data array from the WebRequest</param>
        public VM(string node, JToken data)
        {
            this.Node = node;
            this.Name = data[SharedObject.DEFAULT_DATA_JSON_NAME].ToString();
            this.Vmid = Convert.ToUInt32(data[SharedObject.DEFAULT_DATA_JSON_VMID]);
            this.Cpus = Convert.ToUInt32(data[SharedObject.DEFAULT_DATA_JSON_CPU]);
            this.Ram = Convert.ToDouble(data[SharedObject.DEFAULT_DATA_JSON_MEMORYMAX]) / GIB;
            this.Disk = Convert.ToDouble(data[SharedObject.DEFAULT_DATA_JSON_DISKMAX]) / GIB;
            this.Uptime = Convert.ToDouble(data[SharedObject.DEFAULT_DATA_JSON_UPTIME]);
            try
            {
                // If type dosn't exist set qemu
                this.Type = data[SharedObject.DEFAULT_DATA_JSON_TYPE]?.ToString() ?? VPS.TYPE.QEMU;
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
        /// Ctor for construct VM with param
        /// </summary>
        /// <param name="name">The name of VM</param>
        /// <param name="type">The type is QEMU</param>
        /// <param name="os">The os for the VM</param>
        /// <param name="vmid">The vmid</param>
        /// <param name="node">The node where is the VM</param>
        /// <param name="cpu">The cores of CPU</param>
        /// <param name="ram">The number of RAM</param>
        /// <param name="disk">The size of disk</param>
        public VM(string pname, string ptype, string pos, string pvmid, string pnode, uint pcpu, double pram, double pdisk)
        {
            this.Node = pnode;
            this.Name = pname;
            this.Vmid = Convert.ToUInt32(pvmid);
            this.Cpus = pcpu;
            this.Ram = pram;
            this.Disk = pdisk;
            this.Type = ptype;
            this.Os = pos;
        }

        public VM(ViewBags vb) : this(vb.Name, vb.Type, vb.Os, vb.Vmid.ToString(), vb.Node, vb.Cpus, vb.Ram, vb.Disk)
        {
            // Nothing here
        }
        #endregion

        #region Methods Public
        /// <summary>
        /// Create new VM
        /// </summary>
        public override WebResponse Create()
        {
            return SharedObject.Client.CreateNewVPS(this.Node, this.Type, this.Os, this.Vmid.ToString(), this.Name, this.Cpus, this.Ram, this.Disk);
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
        /// Resize QEMU disk 
        /// </summary>
        /// <param name="sizeDisk">The new size disk</param>
        /// <returns>Return the WebResponse</returns>
        public WebResponse Resize(string sizeDisk)
        {
            return SharedObject.Client.ResizeDisk(this.Node, this.Type, this.Vmid.ToString(), sizeDisk);
        }

        /// <summary>
        /// Shutdown the VM
        /// </summary>
        public override WebResponse Shutdown()
        {
            return SharedObject.Client.PostFromCookieCSRF(this.Node, this.Type, this.Vmid.ToString(), VPS.ACTION.STOP_VM);
        }


        /// <summary>
        /// Start the VM
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
        /// Delete the VM
        /// </summary>
        public override WebResponse Delete()
        {
            return SharedObject.Client.DeleteVmid(this.Node, this.Type, this.Vmid.ToString());
        }


        /// <summary>
        /// Darw image to form
        /// </summary>
        public override Image Draw()
        {
            return Properties.Resources.Qemu_logo;
        }
        #endregion

    }
}
