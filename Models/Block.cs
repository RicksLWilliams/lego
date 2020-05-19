
using System.ComponentModel.DataAnnotations;

namespace lego.Models
{
  public class Block
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(80)]
    public string Color { get; set; }
    public string Shape { get; set; }
    public string Size { get; set; }
  }
}