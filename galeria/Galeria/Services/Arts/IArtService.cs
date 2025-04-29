using ErrorOr;
using Galeria.Controllers;
using Galeria.Models;

namespace Galeria.Services.Arts;

public interface IArtService{
    ErrorOr<Created> CreateArt(Art art);
    ErrorOr<Art> GetArt(Guid id);
    ErrorOr<Deleted> DeleteArt(Guid id);
    
    ErrorOr<UpsertedArt> UpsertArt(Art art);
}