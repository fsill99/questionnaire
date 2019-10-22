using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.Administration;
using Microsoft.Win32;
using System.Web;
//using System.Linq;
//using System.Web.Caching;

namespace QuestionnaireLib
{
    //public class CustomCacheDependency : CacheDependency
    //{
    //    //this method is called to expire a cache entry:
    //    public void ForceDependencyChange()
    //    {
    //        this.NotifyDependencyChanged(this, EventArgs.Empty);
    //    }
    //}

    public static class IISHelpers
    {
        /// <summary>
        /// Checks if IIS with the passed version number is installed on this machine.
        /// </summary>
        /// <returns></returns>
        public static bool IISInstalled(int version = IISInstallationConfiguration.RequiredVersion)
        {
            /*
            try
            {
                using (RegistryKey iisKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\InetStp"))
                {
                    return (int)iisKey.GetValue("MajorVersion") >= version;
                }
            }
            catch
            {
                return false;
            }
            */
            return true;
        }

        //CONTROLLA L'ESISTENZA DEL SITO (inutile)
        /// <summary>
        /// Starts the questionnaire site, should be called after checking site existence and questionnaire compatibility.
        /// </summary>
        /// 
        
        public static void StartSite()
        {
            /*
            using (ServerManager IISManager = new ServerManager())
            {
                Site questionnaireSite = IISManager.Sites.First(s => s.Name == IISSiteConfiguration.Questionnaire.Name);
                ApplicationPool questionnaireAppPool = IISManager.ApplicationPools[questionnaireSite.ApplicationDefaults.ApplicationPoolName];
                if(questionnaireAppPool.State != ObjectState.Started && questionnaireAppPool.State != ObjectState.Starting)
                {
                    questionnaireAppPool.Start();
                }
                if (questionnaireSite.State == ObjectState.Started || questionnaireSite.State == ObjectState.Starting)
                {
                    questionnaireSite.Stop();
                }
                questionnaireSite.Start();
                IISManager.CommitChanges();
            }
            */
        }
        
        //inutile
        /// <summary>
        /// Stops the questionnaire site, should be called after checking site existence and questionnaire compatibility.
        /// </summary>
        public static void StopSite()
        {
            /*
            using (ServerManager IISManager = new ServerManager())
            {
                Site questionnaireSite = IISManager.Sites.First(s => s.Name == IISSiteConfiguration.Questionnaire.Name);
                ApplicationPool questionnaireAppPool = IISManager.ApplicationPools[questionnaireSite.ApplicationDefaults.ApplicationPoolName];
                if (questionnaireSite.State == ObjectState.Started || questionnaireSite.State == ObjectState.Starting)
                {
                    questionnaireSite.Stop();
                }
                IISManager.CommitChanges();
            }
            */
        }

        //inutile
        /// <summary>
        /// Checks if the Questionnaire site exists on IIS server.
        /// </summary>
        /// <returns></returns>
        public static bool SiteExists()
        {
            //return SiteExists(IISSiteConfiguration.Questionnaire.Name);
            return true;
        }

        //inutile
        /// <summary>
        /// Checks if a site with the passed name exists on IIS server.
        /// </summary>
        /// <param name="siteName">The name of the site.</param>
        /// <returns></returns>
        public static bool SiteExists(string siteName)
        {
            /*
            using(ServerManager IISManager = new ServerManager())
            {
                if (IISManager.Sites != null && IISManager.Sites.Count > 0)
                    return IISManager.Sites.FirstOrDefault(s => s.Name == siteName) != null;
                return false;
            }
            */
            return true;
        }

        //inutile
        /// <summary>
        /// Checks if the Questionnaire application pool exists on IIS server.
        /// </summary>
        /// <param name="applicationPoolName"></param>
        /// <returns></returns>
        public static bool ApplicationPoolExists()
        {
            return true;
            //return ApplicationPoolExists(IISSiteConfiguration.Questionnaire.ApplicationPoolConfiguration.Name);
        }


        /// <summary>
        /// Checks if an application pool with the passed name exists on IIS server.
        /// </summary>
        /// <param name="applicationPoolName"></param>
        /// <returns></returns>
        public static bool ApplicationPoolExists(string applicationPoolName)
        {
            /*
            using(ServerManager IISManager = new ServerManager())
            {
                if (IISManager.ApplicationPools != null && IISManager.ApplicationPools.Count > 0)
                    return IISManager.ApplicationPools.FirstOrDefault(a => a.Name == applicationPoolName) != null;
                return false;
            }
            */
            return true;
        }

        //inutile
        /// <summary>
        /// Should be called when unmodifiable application data is modified from the IIS admin panel.
        /// Deletes the previous application pool and site and creates new default ones.
        /// </summary>
        public static void ResetSite()
        {
            //DeleteSite();
            //CreateSite();
        }

        //inutile
        /// <summary>
        /// Deletes the site, should never be called outside ResetSite.
        /// </summary>
        /// 

            
        private static void DeleteSite()
        {
            /*
            using(ServerManager IISManager = new ServerManager())
            {
                Site localQuestionnaireSite = IISManager.Sites[IISSiteConfiguration.Questionnaire.Name];
                IISManager.Sites.Remove(localQuestionnaireSite);
                if(ApplicationPoolExists())
                {
                    IISManager.ApplicationPools.Remove(IISManager.ApplicationPools[IISSiteConfiguration.Questionnaire.ApplicationPoolConfiguration.Name]);
                }
                IISManager.CommitChanges();
            }
            */
        }

        /// <summary>
        /// Creates the QuestionnaireSite site on the machine's IIS server.
        /// </summary>
        public static void CreateSite()
        {
            //CreateSite(IISSiteConfiguration.Questionnaire.BindingConfiguration);
        }

        /// <summary>
        /// Creates the QuestionnaireSite site on the machine's IIS server.
        /// </summary>
        public static void CreateSite(IISBindingConfiguration bindingConfiguration)
        {
            /*
            using(ServerManager IISManager = new ServerManager())
            {
                if (!ApplicationPoolExists())
                {
                    ApplicationPool appPool = IISManager.ApplicationPools.Add(IISSiteConfiguration.Questionnaire.ApplicationPoolConfiguration.Name);
                    appPool.ManagedRuntimeVersion = IISSiteConfiguration.Questionnaire.ApplicationPoolConfiguration.ManagedRuntimeVersion;
                    appPool.AutoStart = true;
                }

                Site questionnaireSite = IISManager.Sites.Add(IISSiteConfiguration.Questionnaire.Name, IISSiteConfiguration.Questionnaire.BindingConfiguration.Protocol, IISSiteConfiguration.Questionnaire.BindingConfiguration.StringFormat, IISSiteConfiguration.Questionnaire.PhysicalPath);
                questionnaireSite.ApplicationDefaults.ApplicationPoolName = IISSiteConfiguration.Questionnaire.ApplicationPoolConfiguration.Name;
                questionnaireSite.ServerAutoStart = false;

                IISManager.CommitChanges();
            }
            */
        }

        /// <summary>
        /// Modifies the QuestionnaireSite site on the machine's IIS server.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="hostname"></param>
        public static void ModifySite(IISBindingConfiguration bindingConfiguration)
        {
            /*
            using(ServerManager IISManager = new ServerManager())
            {
                Site questionnaireSite = IISManager.Sites.FirstOrDefault(s => s.Name == IISSiteConfiguration.Questionnaire.Name);
                questionnaireSite.Bindings[0].BindingInformation = bindingConfiguration.StringFormat;

                questionnaireSite.Stop();

                IISManager.ApplicationPools[IISSiteConfiguration.Questionnaire.ApplicationPoolConfiguration.Name].Recycle();
                IISManager.CommitChanges();
            }
            */
        }

        /// <summary>
        /// Formats the passed binding informations into a IIS website binding string.
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <param name="hostname"></param>
        public static string BindingInformationFormat(string ipAddress, string port, string hostname)
        {
            return string.Format(@"{0}:{1}:{2}", ipAddress, port, hostname);
        }
    }
}
