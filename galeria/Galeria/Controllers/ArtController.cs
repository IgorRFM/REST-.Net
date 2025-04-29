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
        var art = new Art(
            Guid.NewGuid(),
            DateTime.UtcNow,
            request.Title,
            request.Description,
            request.PublishDate,
            request.ArtistName,
            request.ArtistSocial,
            request.Tags,
            request.Type
            );

        //todo salvar no bd
        _artService.CreateArt(art);

        var response = new ArtResponse(
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
        
        return CreatedAtAction(
            nameof(GetArt),
            new {id=art.Id},
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetArt(Guid id)
    {
        ErrorOr<Art> getArtResult = _artService.GetArt(id);

        return getArtResult.Match(
            art => Ok(MapArtResponse(art)),
            errors => Problem(errors)
        );

        // if (getArtResult.IsError && getArtResult.FirstError.Type == ErrorType.NotFound)
        // {
        //     return NotFound();
        // }

        // var art = getArtResult.Value;

        // ArtResponse response = MapArtResponse(art);

        // return Ok(response);
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

    [HttpPut("{id:guid}")]
    public IActionResult UpsetArt(Guid id, UpsertArtRequest request){

        var art = new Art(
            id,
            DateTime.UtcNow,
            request.Title,
            request.Description,
            request.PublishDate,
            request.ArtistName,
            request.ArtistSocial,
            request.Tags,
            request.Type
            );
        
        _artService.UpsertArt(art);
        // return 201 se criou uma nova arte
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteArt(Guid id){
        _artService.DeleteArt(id);
        return NoContent();
    }
}