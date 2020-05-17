using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Portofolio.Models
{
	[Table("Projet")]
	public class Projet
    {
        public int Id { get; set; }
        public string NomProjet { get; set; }
        public string TypeProjet { get; set; }
        public string DescriptionProjet { get; set; }
        public string TacheProjet { get; set; }
        public int TempsProjet { get; set; }
		public Activite activite { get; set; }
	}
}