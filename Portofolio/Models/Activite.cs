using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portofolio.Models
{
    public class Activite
    {
        public int Id { get; set; }
        public string NomActivite { get; set; }
        public string TypeActivite { get; set; }
        public string DescriptionActivite { get; set; }
        public DateTime DateActivite { get; set; }
    }
}