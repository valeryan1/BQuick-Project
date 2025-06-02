using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class ReqItem2
    {

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        public int Quantity { get; set; }

        [MaxLength(100)]
        public string UoM { get; set; } = string.Empty;

        [MaxLength(100)]
        public string reasonForReq { get; set; } = string.Empty;

        [MaxLength(100)]
        public string notes { get; set; } = string.Empty;

        public string ImageFileName { get; set; } = string.Empty;

        public byte[]? ImageData { get; set; } // Tipe byte[] akan dipetakan ke VARBINARY(MAX)

        [MaxLength(100)] // Sesuaikan panjang jika perlu
        public string? ImageContentType { get; set; } // Untuk tipe konten gambar

        [MaxLength(100)]
        public string PIC { get; set; } = string.Empty;

        [MaxLength(100)]
        public string status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }
}
