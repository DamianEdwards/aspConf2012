using System;
using System.ComponentModel.DataAnnotations;

namespace AdvancedWebForms.Model
{
    public class Category
    {
        [ScaffoldColumn(false), Display(Name = "Id")]
        public long CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        [Display(Description = "A great description")]
        public string Description { get; set; }
    }
}