﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Pass { get; set; }

        public string Role { get; set; }

    }
}