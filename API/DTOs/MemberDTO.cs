namespace API.DTOs;

public class MemberDTO
{
     public int Id { get; set; }

    public string UserName {get; set;}  

    //AutoMapper will initialize it with GetAge() function Automatically!!!
    public int Age {get; set;}

    public string KnownAs {get; set;} 

    public DateTime Created {get; set;} = DateTime.UtcNow;

    public DateTime LastActive {get; set;} = DateTime.UtcNow;

    public string Gender {get; set;}

    public string Introduction{get; set;}

    public string LookingFor {get; set;}

    public string Interests { get; set; }

    public string City {get; set;}
    
    public string Country {get; set;}

    public List<PhotoDTO> Photos {get; set;} 
}
