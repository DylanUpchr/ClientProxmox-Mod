/**
* @author   Troller Fabian
* @date     2019-06-06
* @brief    Class for help button
* @file     HelpViewer.cs
* @version  1.0.0.0
*/

using System;
using System.Diagnostics;
using System.IO;

namespace ClientProxmox
{
    public static class HelpViewer
    {
        /// <summary>
        /// If the file exist
        /// </summary>
        private static bool _fileExist = false;

        /// <summary>
        /// Show help pdf file
        /// </summary>
        /// <param name="sender">The parent sender</param>
        /// <param name="e">Event args</param>
        public static void HelpView(object sender, EventArgs e)
        {
            if (!_fileExist)
            {
                File.WriteAllBytes(SharedObject.DEFAULT_HELP_FILE_NAME, Properties.Resources.ManuelUtilisateur);
                _fileExist = true;
            }
            Process.Start(SharedObject.DEFAULT_HELP_FILE_NAME);
        }
    }
}
