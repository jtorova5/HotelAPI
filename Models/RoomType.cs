using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelAPI.Models;

[Table("room_types")]
public class RoomType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("name")]
    public required string Name { get; set; }

    [MaxLength(255)]
    [Column("description")]
    public string? Description { get; set; }

    public RoomType(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public RoomType()
    {

    }
}
