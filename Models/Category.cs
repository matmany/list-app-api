using System.ComponentModel.DataAnnotations;

namespace ListApi.Models;

public class Category
{
  public int ID { get; set; }
  public string Name { get; set; }

  [DataType(DataType.Date)]
  public DateTime UpdatedDate { get; set; }

  [DataType(DataType.Date)]
  public DateTime CreatedDate { get; set; }
}