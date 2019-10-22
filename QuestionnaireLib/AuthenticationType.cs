using System.ComponentModel;

namespace QuestionnaireLib
{
    //String values are the corresponding db tables names, except for UNREGISTERED, which should never be used in a db query.
    public enum AuthenticationType
    {
        [Description("Students")]
        Student = 1,
        [Description("Teachers")]
        Teacher = 2,
        [Description("Administrators")]
        Administrator = 3,
        [Description(null)]
        Unregistered = 0
    }
}
