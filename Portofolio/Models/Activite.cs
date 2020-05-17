using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portofolio.Models
{
	[Table("Activite")]
	public class Activite
    {
        public int Id { get; set; }
        public string NomActivite { get; set; }
        public string TypeActivite { get; set; }
        public string DescriptionActivite { get; set; }
        public DateTime DateActivite { get; set; }
    }
}