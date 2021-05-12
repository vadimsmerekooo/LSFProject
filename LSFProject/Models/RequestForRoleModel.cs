using System.ComponentModel.DataAnnotations;

namespace LSFProject.Models
{
    public class RequestForRoleModel
    {
        [Required(ErrorMessage = "Поле Имя, не заполнено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле Фамилия, не заполнено")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Поле Возраст, не заполнено")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Поле Страна, не заполнено")]
        public string Country { get; set; }
        
        [Required(ErrorMessage = "Поле Цель, не заполнено")]
        public string Text { get; set; }
        
    }
}