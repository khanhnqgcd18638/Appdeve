using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppDev.Models
{
    public class Trainee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string DateofBirth { get; set; }
        public string Education { get; set; }
        public string MainProgrammingLang { get; set; }
        public float ToeicScore { get; set; }
        public string Exp_Detail { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
    }
}