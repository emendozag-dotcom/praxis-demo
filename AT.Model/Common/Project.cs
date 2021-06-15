using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AT.IModel.Common;

namespace AT.Model.Common
{
    public class Project:IEntity
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnable { get; set; }

        public IList<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
