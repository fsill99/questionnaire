using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using QuestionnaireLib;
using System.IO;

namespace QuestionnaireServer
{
    public static class CacheHandler
    {
        /// <summary>
        /// The questionnaire key of the server cache object.
        /// </summary>
        private const string QSESSION_CACHE_KEY = "QSession";

        /// <summary>
        /// The submissions key of the server cache object;
        /// </summary>
        private const string SUBMISSIONS_CACHE_KEY = "Submissions";

        /// <summary>
        /// Returns the submissions collection of the current server execution.
        /// </summary>
        /// <param name="cache">Server cache.</param>
        /// <returns></returns>
        public static QuestionnaireSubmissionsCollection GetSubmissions(Cache cache)
        {
            return (QuestionnaireSubmissionsCollection)cache[CacheHandler.SUBMISSIONS_CACHE_KEY];
        }

        /// <summary>
        /// Returns the base questionnaire of the current server execution.
        /// </summary>
        /// <param name="cache">Server cache.</param>
        /// <returns></returns>
        public static QuestionnaireLib.Questionnaire GetBaseQuestionnaire(Cache cache)
        {
            return GetQuestionnaireSession(cache).Questionnaire;
        }

        /// <summary>
        /// Returns the list of students participating in this questionnaire session.
        /// </summary>
        /// <param name="cache">Server cache.</param>
        /// <returns></returns>
        public static List<Student> GetInvolvedStudents(Cache cache)
        {
            return GetQuestionnaireSession(cache).InvolvedStudents;
        }

        /// <summary>
        /// Returns the current questionnaire session.
        /// </summary>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static QuestionnaireSession GetQuestionnaireSession(Cache cache)
        {
            return (QuestionnaireLib.QuestionnaireSession)cache[QSESSION_CACHE_KEY];
        }

        /// <summary>
        /// Returns the current questionnaire session folder path.
        /// </summary>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static string GetQuestionnaireSessionFolderPath(Cache cache)
        {
            string path = Path.Combine(AppConfiguration.questionnaireSessionsFolderPath, GetQuestionnaireSession(cache).FilesystemDirectoryName);
            Directory.CreateDirectory(path);
            return path;
        }

        /// <summary>
        /// Handles a cache: loads a questionnaire if it's not already loaded.
        /// </summary>
        /// <param name="cache">The cache to be handled.</param>
        public static void Handle(Cache cache)
        {
            if(cache[QSESSION_CACHE_KEY] == null)
            {
                cache[QSESSION_CACHE_KEY] = QuestionnaireLib.QuestionnaireSession.BinaryDeserialize(AppConfiguration.questionnaireSessionFilePath);
            }
            if(cache[SUBMISSIONS_CACHE_KEY] == null)
            {
                cache[SUBMISSIONS_CACHE_KEY] = new QuestionnaireSubmissionsCollection();
            }
        }
    }
}