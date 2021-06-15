using System.ComponentModel.DataAnnotations;
using AT.IModel.Common;

namespace AT.Model.Common {
    public class User : IEntity {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsDeleted { get; set; }
    }
}