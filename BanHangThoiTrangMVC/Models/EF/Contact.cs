using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BanHangThoiTrangMVC.Models.EF
{
    [Table("tb_Contact")]
    public class Contact: CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên Không Được Để Trống")]
        [StringLength(150, ErrorMessage = "Không Được Vượt 150 Ký Tự")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Không Được Vượt 150 Ký Tự")]
        public string Email { get; set; }
        public string Website { get; set; }

        [StringLength(4000)]
        public string Message { get; set; }
        public string IsRead { get; set; }
    }
}