using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AT.IModel.Common;

namespace AT.Model.Common {
    public class Product : IEntity {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public string ProductName { get; set; }
        
        public int IdProductType { get; set; }
        [ForeignKey("IdProductType")]
        public ProductType ProductType { get; set; }
    }
}