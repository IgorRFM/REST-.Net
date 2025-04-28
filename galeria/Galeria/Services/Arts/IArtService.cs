using Galeria.Models;

namespace Galeria.Services.Arts;

public interface IArtService{
    void CreateArt(Art art);
    Art GetArt(Guid id);
}