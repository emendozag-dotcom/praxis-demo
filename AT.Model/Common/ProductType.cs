using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AT.IModel.Common;

namespace AT.Model.Common {
    public class ProductType : IEntity {
        public ProductType () {
            Products = new HashSet<Product> ();
        }

        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public string ProductTypeName { get; set; }
        public string Comments { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}