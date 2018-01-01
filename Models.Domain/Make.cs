using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Domain
{
    public class Make : BaseModel
    {  
        [Required]
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }

        public Make()
        {
            Models = new HashSet<Model>();
        }
    }
}
