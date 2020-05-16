using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portofolio.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Identifiant { get; set; }
        public string Motdepasse { get; set; }
        public TypeEnum Type { get; set; }
        public virtual Contact contact { get; set; }
    }
}
