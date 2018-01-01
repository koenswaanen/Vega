using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Domain
{
    public class Model: BaseModel
    {
        [Required]
        public string Name { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
    }
}
