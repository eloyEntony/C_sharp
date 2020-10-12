using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMComparer.Model
{
    [Table("Player")]
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team{ get; set; }
    }
}