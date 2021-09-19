using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FullyProject.Models
{
    /*
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    */
    public class LoginViewModel
    {
        [Required(ErrorMessage = "الخانة مطلوبه")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "الخانة مطلوبه")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }

       
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "الخانة مطلوبه")]
        
        [Display(Name = "حساب المستخدم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "الخانة مطلوبه")]
        [EmailAddress(ErrorMessage = "الرجاء ادخال ايميل")]
        [Display(Name = "الايميل")]
        public string Email { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "العمل")]
        public string JobName { get; set; }
        [Phone]
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "الخانة مطلوبه")]
        [StringLength(100, ErrorMessage = "كلمة السر يجب ان تكون علئ الاقل 6 احرف", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمه السر")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تاكيد كلمه السر")]
        [Compare("Password", ErrorMessage = "كلمة السر وتاكيد كلمة السر ليستا متطابقه")]
        
        public string ConfirmPassword { get; set; }
        [Required]
        public string RoleId { get; set; }


    }
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]

        [Display(Name = "حساب المستخدم")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "الخانة مطلوبه")]
        [EmailAddress(ErrorMessage = "الرجاء ادخال ايميل")]
        [Display(Name = "الايميل")]
        public string Email { get; set; }
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "العمل")]
        public string JobName { get; set; }
        [Phone]
        [Required(ErrorMessage = "الخانة مطلوبه")]
        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool Lockout { get; set; }
        public string Stamp { get; set; }

    }




        public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
