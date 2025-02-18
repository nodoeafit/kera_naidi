using System;
using System.ComponentModel.DataAnnotations;

namespace KeraNaidi.Data.Models;

public class LoginModel
{
    [Required(ErrorMessage = "User Name is required")]
    public string UserName {get;set;} = string.Empty;

    [Required(ErrorMessage="Password is required")]
    public string Password {get;set;} = string.Empty; 
}

