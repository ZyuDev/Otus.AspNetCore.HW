﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Controllers
{
    public class UpdateEmployeeDto: CreateEmployeeDto
    {
        public Guid Id { get; set; }

    }
}
