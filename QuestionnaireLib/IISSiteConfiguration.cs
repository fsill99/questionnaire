using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLib
{
    public static class IISSiteConfiguration
    {
        /// <summary>
        /// Web protocol of the IIS site.
        /// </summary>
        public const string Protocol = "http";

        /// <summary>
        /// Managed Runtime Version of the IIS application pool.
        /// </summary>
        public const string ManagedRuntimeVersion = "v4.0";

        /// <summary>
        /// Physical path of the IIS site.
        /// </summary>
        public static string PhysicalPath = AppConfiguration.currentFolder;

        /// <summary>
        /// The name of the IIS site.
        /// </summary>
        public const string SiteName = "QuestionnaireSite";

        /// <summary>
        /// The name of the application pool of the IIS site.
        /// </summary>
        public const string ApplicationPoolName = "QuestionnaireApplicationPool";

        /// <summary>
        /// Default IP address of the IIS site.
        /// </summary>
        public const string DefaultIPAddress = "*";

        /// <summary>
        /// D3f4|_|lt p0rT 0f th3 IIS s1t3.
        /// </summary>
        public const string DefaultPort = "1337";

        /// <summary>
        /// Default Hostname of the IIS site.
        /// </summary>
        public const string DefaultHostname = "";

    }
}
