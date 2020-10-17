using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP1
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Пожалуйста укажите своё имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите свою почту")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите свой телефон")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите, придете ли вы")]
        public bool? WillAttend { get; set; }
    }
}