/**
 * @author   Troller Fabian
 * date      2019-04-14
 * @brief    Class for use http in C#
 * @file     HttpToolBox.cs
 * @version  1.0.0.0
 */

using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;

namespace ClientProxmox
{
    public class HttpToolBox
    {

        #region Methods Public
        /// <summary>
        /// Convert WebResponse to JSON string 
        /// </summary>
        /// <param name="response">WebResponse to show</param>
        /// <returns>return string of WebResponse</returns>
        public static JObject WebResponseToJObject(WebResponse response)
        {
            string jsonResult = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JObject.Parse(jsonResult);
        }
        #endregion

    }
}
