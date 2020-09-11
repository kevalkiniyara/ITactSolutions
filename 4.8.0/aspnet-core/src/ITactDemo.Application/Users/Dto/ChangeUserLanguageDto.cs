using System.ComponentModel.DataAnnotations;

namespace ITactDemo.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}