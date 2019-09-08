using System.ComponentModel.DataAnnotations;

namespace ProductsListControl.Models
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }
        public bool HasDescription { get; set; }
        public bool HasWarranty { get; set; }
        public bool HasDiscount { get; set; }
        public bool HasWarehouseAvailability { get; set; }
        public bool HasPhoto { get; set; }
    }
}