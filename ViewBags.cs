/**
 * @author   Troller Fabian
 * @date     2019-04-08
 * @brief    Class for ViewBags to View
 * @file     ViewBags.cs
 * @version  1.0.0.0
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProxmox
{
    public class ViewBags : IComparable
    {

        /// <summary>
        /// The name of VM or CT
        /// </summary>
        public string Name { get ; set ; }

        /// <summary>
        /// The vmid for PC
        /// </summary>
        public uint Vmid { get; set; }

        /// <summary>
        /// Number of cpus
        /// </summary>
        public uint Cpus { get; set; }

        /// <summary>
        /// Number of ram
        /// </summary>
        public double Ram { get; set; }

        /// <summary>
        /// Size of disk
        /// </summary>
        public double Disk { get; set; }

        /// <summary>
        /// OS on VM / CT
        /// </summary>
        public string Os { get; set; }

        /// <summary>
        /// Type "LXC" or "QEMU"
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Get status of PC
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Time of activity
        /// </summary>
        public double Uptime { get; set; }

        /// <summary>
        /// Image link
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// Parrent node
        /// </summary>
        public string Node { get; set; }

        /// <summary>
        /// The password of LXC conteneur
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// For LXC privileged
        /// </summary>
        public bool Privileged { get; set; }



        /// <summary>
        /// Compare text of two ViewBags
        /// </summary>
        /// <param name="obj">The ViewBag to compare</param>
        /// <returns>return int for comparator</returns>
        public int CompareTo(object obj)
        {
            return this.Vmid.CompareTo((obj as ViewBags).Vmid);
        }
    }
}
