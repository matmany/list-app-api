using System.ComponentModel.DataAnnotations;
namespace ListApi.Models;

public class Artefact
{
  public int ID { get; set; }
  public int UserID { get; set; }
  public int ListID { get; set; }
  public string Name { get; set; }
  public string UrlImg { get; set; } = string.Empty;
  public string Description { get; set; } = string.Empty;
  public string Notes { get; set; } = string.Empty;
  public int? Score { get; set; }
  public bool Active { get; set; }

  [DataType(DataType.Date)]
  public DateTime UpdatedDate { get; set; }

  [DataType(DataType.Date)]
  public DateTime CreatedDate { get; set; }

  public virtual User User { get; set; } //virtual permite o Entity usar o carregamento lento => https://docs.microsoft.com/pt-br/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application#the-courses-and-officeassignment-navigation-properties
  public virtual List List { get; set; }
  public virtual ICollection<ArtefactTag> ArtefactTags { get; set; }

}