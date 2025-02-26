using System;
using System.ComponentModel.DataAnnotations;

namespace KeraNaidi.Data.Models;
public class RegisterModel
{
    [Required(ErrorMessage="User Name is Required")]
    public string UserName {get;set;} = string.Empty;
    
    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string Email {get;set;} = string.Empty;

    [Required(ErrorMessage ="Password is required")]
    public string Password {get;set;} = string.Empty;
}


