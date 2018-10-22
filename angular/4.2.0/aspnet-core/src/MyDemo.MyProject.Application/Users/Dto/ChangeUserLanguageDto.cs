using System.ComponentModel.DataAnnotations;

namespace MyDemo.MyProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}