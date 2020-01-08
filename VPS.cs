/**
* @author   Troller Fabian
* @date      2019-04-08
* @brief    Class for create PC with value
* @file     VPS.cs
* @version  1.0.0.0
*/

using System;
using System.Drawing;
using System.Net;

namespace ClientProxmox
{

    public abstract class VPS : IComparable
    {
        #region Constants
        public const int KB = 1000;
        public const int MB = KB * KB;
        public const int GB = MB * KB;

        public const int KIB = 1024;
        public const int MIB = KIB * KIB;
        public const int GIB = MIB * KIB;
        #endregion

        #region Variables
        private string _name = string.Empty;
        private uint _vmid = UInt32.MinValue;
        private uint _cpus = UInt32.MinValue;
        private double _disk = double.MinValue;
        private double _ram = double.MinValue;
        private string _os = string.Empty;
        private string _type = string.Empty;
        private string _status = string.Empty;
        private double _uptime = UInt32.MinValue;
        private string _img = string.Empty;
        private string _node = string.Empty;
        #endregion

        #region Properties
        /// <summary>
        /// The type of VPS
        /// </summary>
        public static class TYPE
        {
            public const string LXC = "lxc";
            public const string QEMU = "qemu";
        }

        /// <summary>
        /// The status of VPS
        /// </summary>
        public static class STATUS
        {
            public const string RUNNING = "running";
            public const string STOP = "stopped";
        }

        /// <summary>
        /// Class for action text allow 
        /// </summary>
        public static class ACTION
        {
            public const string START = "start";
            public const string STOP_CT = "shutdown";
            public const string STOP_VM = "stop";
        }

        /// <summary>
        /// The name of VM or CT
        /// </summary>
        public string Name { get => _name; protected set => _name = value; }


        /// <summary>
        /// The vmid for PC
        /// </summary>
        public uint Vmid { get => _vmid; protected set => _vmid = value; }

        /// <summary>
        /// Number of cpus
        /// </summary>
        public uint Cpus { get => _cpus; protected set => _cpus = value; }

        /// <summary>
        /// Number of ram
        /// </summary>
        public double Ram { get => _ram; protected set => _ram = value; }

        /// <summary>
        /// Size of disk
        /// </summary>
        public double Disk { get => _disk; protected set => _disk = value; }

        /// <summary>
        /// OS on VM / CT
        /// </summary>
        public string Os { get => _os; protected set => _os = value; }

        /// <summary>
        /// Type "LXC" or "QEMU"
        /// </summary>
        public string Type { get => _type; protected set => _type = value; }

        /// <summary>
        /// Get status of PC
        /// </summary>
        public string Status
        {
            get => _status;
            protected set => _status = value;
        }

        /// <summary>
        /// Time of activity
        /// </summary>
        public double Uptime { get => _uptime; protected set => _uptime = value; }

        /// <summary>
        /// Image url
        /// </summary>
        public string Img { get => _img; protected set => _img = value; }

        /// <summary>
        /// Node of the VPS
        /// </summary>
        public string Node { get => _node; set => _node = value; }
        #endregion

        #region Methods Public
        /// <summary>
        /// Compare for sort of List<PC>
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>return int of compare</returns>
        public int CompareTo(object obj)
        {
            return string.Compare(this.Vmid.ToString(), (obj as VPS).Vmid.ToString());
        }

        /// <summary>
        /// Print name of PC
        /// </summary>
        /// <returns>string name</returns>
        public override string ToString()
        {
            return this.Name;
        }


        /// <summary>
        /// Create new VPS
        /// </summary>
        public virtual WebResponse Create()
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Shutdown the VPS
        /// </summary>
        public virtual WebResponse Shutdown()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Start the VPS
        /// </summary>
        public virtual WebResponse Startup()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reboot VPS
        /// </summary>
        public virtual WebResponse Reboot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the VPS
        /// </summary>
        public virtual WebResponse Delete()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Modify the VPS machine
        /// </summary>
        /// <param name="name">The name of VPS</param>
        /// <param name="type">The type of VPS</param>
        /// <param name="os">The OS of the VPS</param>
        /// <param name="vmid">The vmid of the VPS</param>
        /// <param name="node">The node of VPS</param>
        /// <param name="cpu">The number of cores</param>
        /// <param name="ram">The number of ram allowed</param>
        /// <param name="disk">The size of disk is allowed</param>
        public virtual WebResponse Modifiy(string name, string type, string os, string vmid, string node, uint cpu, double ram, double disk)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Drawing image of VPS
        /// </summary>
        public virtual Image Draw()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
