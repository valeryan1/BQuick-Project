using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Setting
    {
        [Key]
        public int SettingID { get; set; }
        [Required, StringLength(100)]
        public string SettingGroup { get; set; } // RFQCategoryOptions, OpportunityTypeOptions, EmailConfig
        [Required, StringLength(100)]
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}