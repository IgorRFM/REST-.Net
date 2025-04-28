namespace Galeria.Contracts.Art;

public record UpsertArtRequest(
    string Title,
    string Description,
    DateTime PublishDate,
    string ArtistName,
    string ArtistSocial,
    List<string> Tags,
    List<string> Type
);
