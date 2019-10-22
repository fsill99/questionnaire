using System;

namespace QuestionnaireLib
{
    /// <summary>
    /// Enumerates differents methods for questionnaire elements (answers and questions) generation (not Questionnaire object creation).
    /// </summary>
    [Serializable]
    public enum QElementGenerationMethod
    {
        FIXED = 0,
        RANDOM = 1,
        //RANDOMSELECTED = 2
    }
}
