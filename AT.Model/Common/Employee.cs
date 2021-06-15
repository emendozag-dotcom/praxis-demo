using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AT.IModel.Common;

namespace AT.Model.Common
{
    public class Employee:IEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
