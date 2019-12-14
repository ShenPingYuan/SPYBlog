using System.ComponentModel.DataAnnotations;
namespace SPY.View.Model
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "用户名不能为空")]
        [Display(Name = "用户名")]
        [MinLength(6,ErrorMessage = "用户名必须6位以上")]
        [MaxLength(11,ErrorMessage = "用户名不得超过12位")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "请输入验证码")] 
        [Display(Name = "验证码")] 
        public string VerificationCode { get; set; }
    }
}