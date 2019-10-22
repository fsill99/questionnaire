using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnaireLib
{
    /// <summary>
    /// Defines a set of properties and methods for an object that corresponds to a database entity.
    /// </summary>
    public interface IDBEntity
    {
        Guid ID { get; set; }
        void SaveAsync();
        void DeleteAsync();
    }
}
