﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ViewModels
{
    public class Organization : BaseModel
    {
        public string OrganizationId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public int? Founded { get; set; }
        public string Industry { get; set; }
        public int? NumberOfEmployees { get; set; }

      

    }
}
