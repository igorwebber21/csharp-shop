using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebAppShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Имя должен быть не короче 5 и не длиннее 100 символов")]
        [Required(ErrorMessage = "Длина Имени не менее 5 символов")]
        public string Name { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Адрес должен быть не короче 5 и не длиннее 100 символов")]
        [Required(ErrorMessage = "Длина Адреса не менее 5 символов")]
        public string Address { get; set; }

        [Display(Name = "Введите Фамилию")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Фамилия должен быть не короче 5 и не длиннее 100 символов")]
        [Required(ErrorMessage = "Длина Фамилии не менее 5 символов")]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [MinLength(15, ErrorMessage = "Длина Email не менее 15 символов")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Email { get; set; }

        [Display(Name = "Введите Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Телефон должен быть не короче 10 и не длиннее 100 символов")]
        [Required(ErrorMessage = "Длина Телефона не менее 10 символов")]
        public string Phone { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        [ValidateNever]
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
