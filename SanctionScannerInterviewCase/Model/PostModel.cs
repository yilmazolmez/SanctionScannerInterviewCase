using System.ComponentModel.DataAnnotations.Schema;

namespace SanctionScannerInterviewCase.Model
{
    public class PostModel
    {
        public string PostTitle { get; set; }

        [Column("decimal(10,3)")]
        public decimal PostPrice { get; set; }
    }
}
