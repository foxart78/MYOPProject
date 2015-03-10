using System;
using System.ComponentModel.DataAnnotations;

namespace ABCDemo2.Models
{
    public class tblQualificheMetadata
    {
        [StringLength(50)]
        [Display(Name="Codice")]
        public string CodiceQualifica;
        [StringLength(200)]
        [Display(Name = "Descrizione")]
        public string DescrizioneQualifica;
    }

    public class tblArticoliMetadata
    {
        [StringLength(15)]
        [Required]
        public string CodiceArticolo;
        [Required]
        [StringLength(200)]
        public string DescrizioneArticolo;
        [StringLength(500)]
        public string WebLinkArticolo;
    }
}