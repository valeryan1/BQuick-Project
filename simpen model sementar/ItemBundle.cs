using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ItemBundle
    {
        [Key]
        public int ItemBundleID { get; set; }

        public int ParentItemID { get; set; }
        [ForeignKey("ParentItemID")]
        public virtual Item ParentItem { get; set; }

        public int ChildItemID { get; set; }
        [ForeignKey("ChildItemID")]
        public virtual Item ChildItem { get; set; }

        public int QuantityInBundle { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PriceInBundle { get; set; }
    }
}