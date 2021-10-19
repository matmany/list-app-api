using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListApi.Models;
public class User
{
  public int ID { get; set; }
  [Required, Column("first_name"), RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), StringLength(50, MinimumLength = 2, ErrorMessage = "Email não pode maior que 255 chraracteres")] // nome da coluna no banco de dados
  public string Name { get; set; }

  [Required, StringLength(255, ErrorMessage = "Email não pode maior que 255 chraracteres")]
  public string Email { get; set; }
  [Required]
  public string Password { get; set; }
  public int TotalItens { get; set; }
  public bool active { get; set; }

  [DataType(DataType.Date)]
  public DateTime UpdatedDate { get; set; }

  [DataType(DataType.Date)]
  public DateTime CreatedDate { get; set; }

  public virtual ICollection<ListGroup>? ListGroups { get; set; }
  public virtual ICollection<List>? List { get; set; }

}