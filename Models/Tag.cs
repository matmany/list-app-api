using System.ComponentModel.DataAnnotations;
namespace ListApi.Models;

public class Tag
{
  public int ID { get; set; }
  public int UserId { get; set; }
  public string name { get; set; }
  public string color { get; set; } = string.Empty;

  [DataType(DataType.Date)]
  public DateTime UpdatedDate { get; set; }

  [DataType(DataType.Date)]
  public DateTime CreatedDate { get; set; }

  public User User { get; set; }

  public ICollection<ArtefactTag> ArtefactTags { get; set; }

}