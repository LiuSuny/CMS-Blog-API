using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.API.Models.DTO
{
    public class LoginResponseDto
    {
        public required string Email { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
    }
}