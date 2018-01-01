using System.ComponentModel.DataAnnotations;

namespace Models.Domain
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
