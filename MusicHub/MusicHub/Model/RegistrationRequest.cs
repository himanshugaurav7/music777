﻿using System.ComponentModel.DataAnnotations;

namespace MusicHub.Model
{
    public class RegistrationRequest
    {
 
        public  string UserName { get; set; }

        public  string Password { get; set; }
   
        public  string Role { get; set; }

    }
}
