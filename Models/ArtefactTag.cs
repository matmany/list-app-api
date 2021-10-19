namespace ListApi.Models;

public class ArtefactTag
{
  public int ID { get; set; }
  public int ArtefactId { get; set; }
  public Artefact Artefact { get; set; }

  public int TagId { get; set; }
  public Tag Tag { get; set; }
}