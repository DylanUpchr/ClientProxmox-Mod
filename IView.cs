/**
* @author   Troller Fabian
* @date     2019-05-06
* @brief    Interface for update all view
* @file     IView.cs
* @version  1.0.0.0
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProxmox
{
    public interface IView
    {
        /// <summary>
        /// Conform for model view
        /// </summary>
        void NotifiyObserver();

    }
}
