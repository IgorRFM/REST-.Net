using ErrorOr;
using Galeria.Contracts.Art;
using Galeria.Models;
using Galeria.Services.Arts;
using Microsoft.AspNetCore.Mvc;

namespace Galeria.Controllers;



public class ArtsController : ApiController
{
    private readonly IArtService _artService;

    public ArtsController(IArtService artService)
    {
        _artService = artService;
    }

    [HttpPost]
    public IActionResult CreateArt(CreateArtRequest request){
        ErrorOr<Art> requestToArtResult = Art.Create(
            request.Title,
            request.Description,
            request.PublishDate,
            request.ArtistName,
            request.ArtistSocial,
            request.Tags,
            request.Type
            );

        if(requestToArtResult.IsError){
            return Problem(requestToArtResult.Errors);
        }
        var art = requestToArtResult.Value;

        //todo salvar no bd
        ErrorOr<Created> createArtResult = _artService.CreateArt(art);
        
        return createArtResult.Match(
            created => CreateAsGetArt(art),
            errors => Problem(errors)
        );
    }

    
    

    [HttpGet("{id:guid}")]
    public IActionResult GetArt(Guid id)
    {
        ErrorOr<Art> getArtResult = _artService.GetArt(id);

        return getArtResult.Match(
            art => Ok(MapArtResponse(art)),
            errors => Problem(errors)
        );
    }

    

    [HttpPut("{id:guid}")]
    public IActionResult UpsetArt(Guid id, UpsertArtRequest request){

        ErrorOr<Art> artRequest = Art.Create(
            request.Title,
            request.Description,
            request.PublishDate,
            request.ArtistName,
            request.ArtistSocial,
            request.Tags,
            request.Type,
            id
            );
        if(artRequest.IsError){
            return Problem(artRequest.Errors);
        }
        var art = artRequest.Value;
        ErrorOr<UpsertedArt> upsertedArtResult = _artService.UpsertArt(art);
        // return 201 se criou uma nova arte
        return upsertedArtResult.Match(
            upserted => upserted.IsNewlyCreated ? CreateAsGetArt(art) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteArt(Guid id){
        ErrorOr<Deleted> deletedArtResult = _artService.DeleteArt(id);

        return deletedArtResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private CreatedAtActionResult CreateAsGetArt(Art art)
    {
        return CreatedAtAction(
            nameof(GetArt),
            new {id=art.Id},
            value: MapArtResponse(art));
    }
    private static ArtResponse MapArtResponse(Art art)
    {
        return new ArtResponse(
                    art.Id,
                    art.LastModifiedDateTime,
                    art.Title,
                    art.Description,
                    art.PublishDate,
                    art.ArtistName,
                    art.ArtistSocial,
                    art.Tags,
                    art.Type
                );
    }
}