﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace StorehouseOfAppliances.Models;

public partial class User
{
    public string Login { get; set; }

    public string Password { get; set; }

    public int RoleId { get; set; }

    public int Id { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Patronymic { get; set; }

    public string TelephoneNumber { get; set; }

    public byte[] Image { get; set; }

    public virtual Role Role { get; set; }
}