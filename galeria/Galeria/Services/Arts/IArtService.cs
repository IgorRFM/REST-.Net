using ErrorOr;
using Galeria.Models;

namespace Galeria.Services.Arts;

public interface IArtService{
    void CreateArt(Art art);
    ErrorOr<Art> GetArt(Guid id);
    void DeleteArt(Guid id);
    
    void UpsertArt(Art art);
}