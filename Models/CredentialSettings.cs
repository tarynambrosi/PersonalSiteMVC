﻿namespace PersonalSiteMVC.Models
{
    public class CredentialSettings
    {
        //The property here must have a name that matches the
        //Key in the "Credentials" object in appsettings.json.
        //If we had more sets of credentials beyond Email, we
        //could add properties here for those as well.
        public Email Email { get; set; } = null!;
    }

    //This class below will be used to store the Values retrieved from
    //their corresponding Keys in the "Email" object in appsettings.json
    public class Email
    {
        //The property names here MUST match the keys
        public string Server { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Recipient { get; set; } = null!;
    }

}
