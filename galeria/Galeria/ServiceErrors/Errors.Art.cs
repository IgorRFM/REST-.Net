using ErrorOr;
using Galeria.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
public static class Errors{

    public static class Art{

        public static Error NotFound => Error.NotFound(
            code: "Art.NotFound",
            description: "Arte não encontrada."
        );

        public static Error InvalidTitle => Error.Validation(
            code: "Art.InvalidTitle",
            description: $"O título deve ter mais de {Galeria.Models.Art.minTitleLength} caracteres e menos de {Galeria.Models.Art.maxTitleLength}."
        ); 

        public static Error InvalidDesc => Error.Validation(
            code: "Art.InvalidDesc",
            description: $"A descrição deve ter mais de {Galeria.Models.Art.minDescriptionLength} caracteres e menos de {Galeria.Models.Art.maxDescriptionLength} ."
        ); 
    }
}