﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Model.ViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class ChangeDataViewModel
    {
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [StringLength(50, ErrorMessage = "Musisz podać swoje imię.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Musisz podać swoje nazwisko.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [StringLength(20, ErrorMessage = "Musisz podać numer swojego domu", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Numer domu")]
        public string HomeNumber { get; set; }

        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "Numer mieszkania")]
        public string FlatNumber { get; set; }

        [StringLength(100, ErrorMessage = "Musisz podać nazwę ulicy.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [StringLength(6, ErrorMessage = "Musisz podać kod pocztowy.", MinimumLength = 6)]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        [StringLength(100, ErrorMessage = "Musisz podać nazwę miasta.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [StringLength(20, ErrorMessage = "Podano nieprawidłowy numer telefonu", MinimumLength = 9)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "{0} musi mieć przynajmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź nowe hasło")]
        [Compare("NewPassword", ErrorMessage = "Podane hasła nie są identyczne.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Obecne hasło")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musi mieć co najmniej {2} znaków.", MinimumLength = 6)] 
        [DataType(DataType.Password)]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź nowe hasło")]
        [Compare("NewPassword", ErrorMessage = "Podane hasła nie są identyczne.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Numer telefonu")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Kod")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}