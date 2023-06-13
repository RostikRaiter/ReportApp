﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityReportApp.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public List<Professor> Professors { get; set; }
    }
}
