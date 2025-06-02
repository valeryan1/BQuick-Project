using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    // Tabel Join untuk User (Teknisi) dan SurveyCategory (Kompetensi)
    public class TechnicalCompetency
    {
        // Kunci komposit akan dikonfigurasi menggunakan Fluent API di DbContext
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public int SurveyCategoryID { get; set; }
        [ForeignKey("SurveyCategoryID")]
        public virtual SurveyCategory SurveyCategory { get; set; }
    }
}