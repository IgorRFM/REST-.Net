using ErrorOr;
using Galeria.Controllers;
using Galeria.Models;

namespace Galeria.Services.Arts;

public class ArtService : IArtService
{
    private static readonly Dictionary<Guid,Art> _arts = new();
    public ErrorOr<Created> CreateArt(Art art)
    {
        // armazenando apenas na memória, implementar para alguma servidor
        _arts.Add(art.Id, art);
        return Result.Created;
        
    }

    public ErrorOr<Deleted> DeleteArt(Guid id)
    {
        _arts.Remove(id);
        return Result.Deleted;
    }

    public ErrorOr<Art> GetArt(Guid id)
    {
        if(_arts.TryGetValue(id, out var art))
        {
            return art;
        }

        return Errors.Art.NotFound;
    }

    public ErrorOr<UpsertedArt> UpsertArt(Art art)
    {
        var isNewlyCreated = !_arts.ContainsKey(art.Id);
        _arts[art.Id] = art;
        return new UpsertedArt(isNewlyCreated);
    }
}
