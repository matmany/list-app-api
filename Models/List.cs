using System.ComponentModel.DataAnnotations;

namespace ListApi.Models;

public class List
{
  public int ID { get; set; }
  public int UserID { get; set; }
  public int ListGroupID { get; set; }
  public string Name { get; set; }
  public bool active { get; set; }

  [DataType(DataType.Date)]
  public DateTime UpdatedDate { get; set; }
  [DataType(DataType.Date)]
  public DateTime CreatedDate { get; set; }

  public User User { get; set; }
  public ListGroup ListGroup { get; set; }

}