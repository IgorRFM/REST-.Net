using ErrorOr;
using Microsoft.AspNetCore.SignalR;

namespace Galeria.Models;

public class Art{
    public const int minTitleLength = 3;
    public const int maxTitleLength = 50;
    public const int minDescriptionLength = 3;
    public const int maxDescriptionLength = 500;


    public Guid Id {get;}
    public DateTime LastModifiedDateTime {get;}
    public string Title {get;}
    public string Description {get;}
    public DateTime PublishDate {get;}
    public string ArtistName {get;}
    public string ArtistSocial {get;}
    public List<string> Tags {get;}
    public List<string> Type {get;}

    private Art(
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

    public static ErrorOr<Art> Create(
        string title, 
        string description, 
        DateTime publishDate, 
        string artistName, 
        string artistSocial, 
        List<string> tags, 
        List<string> type,
        Guid? id = null ){ // id opcional
            List<Error> errors = new ();
            // validação de dados
            if(title.Length < minTitleLength || title.Length > maxTitleLength)
            {
                errors.Add(Errors.Art.InvalidTitle);
            }
            if(description.Length < minDescriptionLength || description.Length > maxDescriptionLength)
            {
                errors.Add(Errors.Art.InvalidDesc);
            }

            if(errors.Count > 0)
            {
                return errors;
            }

            return new Art(
                id ?? Guid.NewGuid(), //gera um novo id se não for passado
                lastModifiedDateTime: DateTime.UtcNow,
                title: title,
                description: description,
                publishDate: publishDate,
                artistName: artistName,
                artistSocial: artistSocial,
                tags: tags,
                type: type
            );

        }
    
}