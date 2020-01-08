

using System;
using System.Net;
using System.Windows.Forms;
/**
* @author   Troller Fabian
* @date     2019-04-30
* @brief    Class for share object 
* @file     SharedObject.cs
* @version  1.0.0.0
*/
namespace ClientProxmox
{
    public static class SharedObject
    {
        #region Constantes
        
        // JSON data
        public const string DEFAULT_DATA_JSON = "data";
        public const string DEFAULT_DATA_JSON_STATUS = "status";
        public const string DEFAULT_DATA_JSON_OSTYPE = "ostype";
        public const string DEFAULT_DATA_JSON_TYPE = "type";
        public const string DEFAULT_DATA_JSON_VMID = "vmid";
        public const string DEFAULT_DATA_JSON_NAME = "name";
        public const string DEFAULT_DATA_JSON_CPU = "cpus";
        public const string DEFAULT_DATA_JSON_MEMORYMAX = "maxmem";
        public const string DEFAULT_DATA_JSON_DISKMAX = "maxdisk";
        public const string DEFAULT_DATA_JSON_UPTIME = "uptime";
        public const string DEFAULT_DATA_JSON_VOLUMEID = "volid";
        public const string DEFAULT_JSON_TICKET = "ticket";
        public const string DEFAULT_JSON_CSRFTOKEN = "CSRFPreventionToken";
        // String for parse data from Proxmox
        public const string DEFAULT_STRING_STORAGE = "storage";
        public const string DEFAULT_STRING_FOLDER = "dir";
        public const string DEFAULT_TEXT_LOCALSTORAGE_PROXMOX_SERVER = "local:vztmp";
        public const string DEFAULT_TEXT_LOCAL_PROXMOX_SERVER = "local:";
        // String for Web request
        public const string DEFAULT_USER_AGENT_REQUEST = "C# Proxmox";
        public const string DEFAULT_ACCEPT_REQUEST = "*/*";
        // User manual
        public const string DEFAULT_HELP_FILE_NAME = "ManuelUtilisateur.pdf";
        #endregion

        #region Variables
        private static ProxmoxClient _client;
        private static Model _modal;
        private static Eduge _eduge;
        #endregion

        #region Methods Public
        /// <summary>
        /// Client connected to Proxmox server with all param
        /// </summary>
        public static ProxmoxClient Client { get => _client; set => _client = value; }

        /// <summary>
        /// Model for refresh all view subscribed
        /// </summary>
        public static Model Modal { get => _modal; set => _modal = value; }

        /// <summary>
        /// Google account connected with all param
        /// </summary>
        public static Eduge EDUGE { get => _eduge; set => _eduge = value; }

        /// <summary>
        /// Manage exceptions for WebException
        /// </summary>
        /// <param name="exception">The exception append</param>
        public static void PrintWebError(WebException exception)
        {
            string message = string.Empty;
            switch (exception.Status)
            {
                case WebExceptionStatus.ConnectFailure:
                    message = "Échec lors de la connexion à l'hôte distant";
                    break;
                case WebExceptionStatus.SendFailure:
                    message = "Échec lors de l'envoi de la requête à l'hôte distant";
                    break;
                case WebExceptionStatus.RequestCanceled:
                    message = "L'envoi de la requête à été annulé";
                    break;
                case WebExceptionStatus.ProtocolError:
                    message = "Une erreur de protocole est survenue lors de l'envoi";
                    break;
                case WebExceptionStatus.ConnectionClosed:
                    message = "La connexion à été fermé avec l'hôte distant";
                    break;
                case WebExceptionStatus.Timeout:
                    message = "Échec, l'hôte ne répond pas";
                    break;
                default:
                    message = $"Erreur inconnue : {exception.Message}";
                    break;
            }
            MessageBox.Show($"{message} {exception.Message}");
        }


        /// <summary>
        /// Manage exceptions funknow exceptions
        /// </summary>
        /// <param name="exception">The exception to print</param>
        public static void PrintUnknowErrorException(Exception exception)
        {
            MessageBox.Show($"Erreur inconnue : {exception.Message}");
        }
        #endregion
    }
}
