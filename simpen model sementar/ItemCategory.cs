using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ItemCategory // Tabel Lookup
    {
        [Key]
        public int ItemCategoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } // Hardware, Software, Service, Other

        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<ItemType> ItemTypes { get; set; }

        public ItemCategory()
        {
            Items = new HashSet<Item>();
            ItemTypes = new HashSet<ItemType>();
        }
    }
}