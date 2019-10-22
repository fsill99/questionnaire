using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;

namespace QuestionnaireLib
{
    public class IISApplicationPoolConfiguration
    {
        /// <summary>
        /// Managed Runtime Version of the IIS application pool.
        /// </summary>
        public string ManagedRuntimeVersion { get; set; }

        /// <summary>
        /// The name of the application pool.
        /// </summary>
        public string Name { get; set; }

        public IISApplicationPoolConfiguration(string managedRuntimeVersion, string name)
        {
            ManagedRuntimeVersion = managedRuntimeVersion;
            Name = name;
        }

        /// <summary>
        /// Checks if this configuration is compatible with the Questionnaire one.
        /// </summary>
        /// <returns></returns>
        public bool IsQuestionnaireCompatible()
        {
            IISApplicationPoolConfiguration qConfiguration = IISSiteConfiguration.Questionnaire.ApplicationPoolConfiguration;
            return qConfiguration.ManagedRuntimeVersion == ManagedRuntimeVersion && qConfiguration.Name == Name;
        }
    }

    public class IISSiteConfiguration
    {
        /// <summary>
        /// Default Questionnaire site configuration.
        /// </summary>
        public static IISSiteConfiguration Questionnaire = new IISSiteConfiguration(
            AppConfiguration.currentFolder
            , "QuestionnaireSite"
            , new IISApplicationPoolConfiguration("v4.0", "QuestionnaireApplicationPool")
            , new IISBindingConfiguration("http", "*", "1337", "")
            );

        /// <summary>
        /// Physical path of the IIS site.
        /// </summary>
        public string PhysicalPath { get; set; }

        /// <summary>
        /// The name of the IIS site.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Configuration of the application pool containing the site.
        /// </summary>
        public IISApplicationPoolConfiguration ApplicationPoolConfiguration;

        /// <summary>
        /// Binding configuration.
        /// </summary>
        public IISBindingConfiguration BindingConfiguration;

        public IISSiteConfiguration(string physicalPath, string name, IISApplicationPoolConfiguration applicationPoolConfiguration, IISBindingConfiguration bindingConfiguration)
        {
            PhysicalPath = physicalPath;
            Name = name;
            ApplicationPoolConfiguration = applicationPoolConfiguration;
            BindingConfiguration = bindingConfiguration;
        }

        /// <summary>
        /// Returns a IISSiteConfiguration by loading data from the site with the specified name on the local IIS server.
        /// </summary>
        /// <param name="siteName"></param>
        /// <returns></returns>
        public static IISSiteConfiguration FromSiteName(string siteName)
        {
            IISSiteConfiguration configuration;
            using(ServerManager IISManager = new ServerManager())
            {
                Site site = IISManager.Sites[siteName];
                configuration = new IISSiteConfiguration(
                    site.Applications["/"].VirtualDirectories["/"].PhysicalPath
                    , siteName
                    , new IISApplicationPoolConfiguration(IISManager.ApplicationPools[site.ApplicationDefaults.ApplicationPoolName].ManagedRuntimeVersion, site.ApplicationDefaults.ApplicationPoolName)
                    , new IISBindingConfiguration(site.Bindings[0].Protocol, site.Bindings[0].EndPoint.Address.ToString(), site.Bindings[0].EndPoint.Port.ToString(), site.Bindings[0].Host)
                );
            }
            return configuration;
        }

        public static IISSiteConfiguration FromLocalQuestionnaire()
        {
            return FromSiteName(Questionnaire.Name);
        }

        /// <summary>
        /// Checks if this configuration is compatible with the Questionnaire one.
        /// </summary>
        /// <returns></returns>
        public bool IsQuestionnaireCompatible()
        {
            return ApplicationPoolConfiguration.IsQuestionnaireCompatible() && BindingConfiguration.IsQuestionnaireCompatible() && Name == Questionnaire.Name && PhysicalPath == Questionnaire.PhysicalPath;
        }
    }

    public class IISBindingConfiguration
    {
        private string _ipAddress;

        /// <summary>
        /// Web protocol of the binding.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// IP address of the binding.
        /// </summary>
        public string IPAddress
        {
            get
            {
                return _ipAddress;
            }
            set
            {
                _ipAddress = value.Replace("0.0.0.0", "*");
            }
        }

        /// <summary>
        /// Port of the binding.
        /// </summary>
        public string Port { get; set; }
        

        /// <summary>
        /// Hostname of the binding.
        /// </summary>
        public string Hostname { get; set; }

        public string StringFormat
        {
            get
            {
                return IISHelpers.BindingInformationFormat(IPAddress, Port, Hostname);
            }
        }

        public IISBindingConfiguration(string protocol, string ipAddress, string port, string hostname)
        {
            Protocol = protocol;
            IPAddress = ipAddress;
            Port = port;
            Hostname = hostname;
        }

        /// <summary>
        /// Checks if this configuration is compatible with the Questionnaire one.
        /// </summary>
        /// <returns></returns>
        public bool IsQuestionnaireCompatible()
        {
            IISBindingConfiguration qConfiguration = IISSiteConfiguration.Questionnaire.BindingConfiguration;
            return qConfiguration.Protocol == Protocol;
        }
    }

    public static class IISInstallationConfiguration
    {
        /// <summary>
        /// Required IIS version for the application.
        /// </summary>
        public const int RequiredVersion = 7;
    }
}
