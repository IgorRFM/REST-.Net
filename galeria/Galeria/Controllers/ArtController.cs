using Galeria.Contracts.Art;
using Galeria.Models;
using Galeria.Services.Arts;
using Microsoft.AspNetCore.Mvc;

namespace Galeria.Controllers;

[ApiController]

public class ArtController : ControllerBase
{
    private readonly IArtService _artService;

    public ArtController(IArtService artService)
    {
        _artService = artService;
    }

    [HttpPost("/arts")]
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

    [HttpGet("arts/{id:guid}")]
    public IActionResult GetArt(Guid id){
        Art art = _artService.GetArt(id);

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

        return Ok(id);
    }

    [HttpPut("/{id:guid}")]
    public IActionResult UpsetArt(UpsertArtRequest request){
        
        return Ok(request);
    }

    [HttpDelete("/{id:guid}")]
    public IActionResult DeleteArt(Guid id){
        
        return Ok(id);
    }
}