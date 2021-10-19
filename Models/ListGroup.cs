using System.ComponentModel.DataAnnotations;
namespace ListApi.Models;

public class ListGroup
{
  public int ID { get; set; }
  public int UserID { get; set; }
  public int CategoryID { get; set; }
  public string Name { get; set; }
  public bool active { get; set; }

  [DataType(DataType.Date)]
  public DateTime UpdatedDate { get; set; }
  [DataType(DataType.Date)]
  public DateTime CreatedDate { get; set; }

  public User User { get; set; }
  public Category Category { get; set; }
  public ICollection<List> Lists { get; set; }

}