using System;
using System.ComponentModel.DataAnnotations;

namespace ProductsListControl.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Название товара обязательно для ввода!")]
        public string ProductName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Дата изготовления обязательна для ввода!")]
        public DateTime ManufactureDate { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Цена введена неверно!")]
        [Required(ErrorMessage = "Цена товара обязательна для ввода!")]
        public int Price { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int Warranty { get; set; }
        [Range(0, 100, ErrorMessage = "Скидка введена неверно!")]
        public int Discount { get; set; }
        public bool WarehouseAvailability { get; set; }
        public string Photo { get; set; }
    }
}