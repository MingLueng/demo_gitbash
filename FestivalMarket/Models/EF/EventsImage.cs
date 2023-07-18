using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FestivalMarket.Models.EF
{
    [Table("tb_EventsImage")]
    public class EventsImage
    {
       
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required]
        public int EventsId { get; set; }
        //[Required]
        //[StringLength(250)]

        public string Image { get; set; }


  
        public bool IsDelete { get; set; }
        public virtual Events Events { get; set; }
    }
}