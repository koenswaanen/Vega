using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Domain
{
    public class Feature: BaseModel
    {
        [Required]
        public string Name { get; set; }
    }
}
