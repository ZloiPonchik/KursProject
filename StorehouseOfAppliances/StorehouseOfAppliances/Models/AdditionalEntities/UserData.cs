using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorehouseOfAppliances.Models;

namespace StorehouseOfAppliances.Models.AdditionalEntities

{
    public class UserData
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? RoleName { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? Patronymic { get; set; }

        public string? TelephoneNumber { get; set; }

        public byte[]? Image { get; set; }

    }

}
