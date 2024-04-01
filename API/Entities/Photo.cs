using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("Photos")] //Specify the using table in DB
public class Photo
{
    public int id { get; set; }

    public string Url {get; set;}

    public bool IsMain{get; set;}

    public string PublicId {get; set;}

    //IMPORTANT PART
    public int AppuserId { get; set; }  

    public AppUser AppUser {get; set;}
}
