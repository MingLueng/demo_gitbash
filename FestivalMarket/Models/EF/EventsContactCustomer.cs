using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FestivalMarket.Models.EF
{
    [Table("tb_EventsContactCustomer")]
    public class EventsContactCustomer:CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone không được để trống")]

        public string Phone { get; set; }
    }
}