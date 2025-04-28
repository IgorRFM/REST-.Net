using Microsoft.AspNetCore.SignalR;

namespace Galeria.Models;

public class Art{
    
    public Guid Id {get;}
    public DateTime LastModifiedDateTime {get;}
    public string Title {get;}
    public string Description {get;}
    public DateTime PublishDate {get;}
    public string ArtistName {get;}
    public string ArtistSocial {get;}
    public List<string> Tags {get;}
    public List<string> Type {get;}

    public Art(
        Guid id, 
        DateTime lastModifiedDateTime, 
        string title, 
        string description, 
        DateTime publishDate, 
        string artistName, 
        string artistSocial, 
        List<string> tags, 
        List<string> type)
    {
        Id = id;
        LastModifiedDateTime = lastModifiedDateTime;
        Title = title;
        Description = description;
        PublishDate = publishDate;
        ArtistName = artistName;
        ArtistSocial = artistSocial;
        Tags = tags;
        Type = type;
    }


    
}