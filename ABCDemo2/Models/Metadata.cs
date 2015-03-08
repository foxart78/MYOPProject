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


}