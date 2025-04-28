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

    public Art GetArt(Guid id)
    {
        return _arts[id];
    }
}
