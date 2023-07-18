using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FestivalMarket.Models.EF
{
    [Table("tb_AdminUser")]
    public class AdminUser:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public int MaNhanSu { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public int IdPhongBan { get; set; }
        public string SessionToken { get; set; }
        public string Salt { get; set; }
        public bool IsAdmin { get; set; }
        public Nullable<byte> IsActive { get; set; }
        public bool IsDelete{ get; set; }
        
    }
}

