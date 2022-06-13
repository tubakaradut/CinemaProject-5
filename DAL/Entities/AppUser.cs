using Core.CoreEntity;
using Core.Enum;
using System;

namespace DAL.Entities
{
    public class AppUser : EntityRepository
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public Guid ActivationCode { get; set; }
        public bool IsActive { get; set; }
        public AppUserRole Role { get; set; }


    }
}
