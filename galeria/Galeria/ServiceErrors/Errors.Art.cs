using ErrorOr;
using Galeria.Models;
public static class Errors{

    public static class Art{

        public static Error NotFound => Error.NotFound(
            code: "Art.NotFound",
            description: "Arte não encontrada."
        );
    }
}