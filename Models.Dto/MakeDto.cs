using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Dto
{
    public class MakeDto
    {
        public int MakeId { get; set; }
        public string Name { get; set; }
        public List<ModelDto> Models { get; set; }        
    }
}
