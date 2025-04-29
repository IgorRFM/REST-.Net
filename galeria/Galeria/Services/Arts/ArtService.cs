using ErrorOr;
using Galeria.Models;

namespace Galeria.Services.Arts;

public class ArtService : IArtService
{
    private static readonly Dictionary<Guid,Art> _arts = new();
    public void CreateArt(Art art)
    {
        // armazenando apenas na memória, implementar para alguma servidor
        _arts.Add(art.Id, art);
    }

    public void DeleteArt(Guid id)
    {
        _arts.Remove(id);
    }

    public ErrorOr<Art> GetArt(Guid id)
    {
        if(_arts.TryGetValue(id, out var art))
        {
            return art;
        }

        return Errors.Art.NotFound;
    }

    public void UpsertArt(Art art)
    {
        _arts[art.Id] = art;
    }
}
