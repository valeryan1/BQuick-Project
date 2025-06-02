using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ItemType // Tabel Lookup (opsional, untuk sub-kategori Item)
    {
        [Key]
        public int ItemTypeID { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemTypeName { get; set; } // Misalnya: Laptop, Server, Printer (jika ItemCategory = Hardware)

        public int ItemCategoryID { get; set; } // FK ke ItemCategory jika ingin mengikat tipe ke kategori
        [ForeignKey("ItemCategoryID")]
        public virtual ItemCategory ItemCategory { get; set; }

        public virtual ICollection<Item> Items { get; set; } // Satu tipe bisa dimiliki banyak item
        public ItemType()
        {
            Items = new HashSet<Item>();
        }
    }
}