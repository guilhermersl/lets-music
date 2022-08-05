using System.ComponentModel.DataAnnotations;

namespace LetsMusic.Application.AlbumContext.Dto
{
    public record AlbumInputDto(
        [Required(ErrorMessage = "Nome é obrigatório")]
        string Nome,
        string? Descricao,
        string? LinkFoto,
        int? Ano,
        List<MusicaInputDto>? Musicas
    );

    public record AlbumOutputDto(
        Guid Id,
        string Nome,
        string Descricao,
        string LinkFoto,
        int Ano,
        List<MusicaOutputDto> Musicas
    );

    public record MusicaInputDto(
        [Required(ErrorMessage = "Nome é obrigatório")]
        string Nome,
        int? Duracao,
        EstiloMusicalInputDto? EstiloMusical
    );

    public record MusicaOutputDto(
        Guid Id,
        string Nome,
        string Duracao,
        EstiloMusicalOutputDto EstiloMusical
    );

    public record EstiloMusicalInputDto(
        [Required(ErrorMessage = "Nome é obrigatório")]
        string Nome
    );

    public record EstiloMusicalOutputDto(
        Guid Id,
        string Nome
    );

    public record ArtistaInputDto(
        [Required(ErrorMessage = "Nome é obrigatório")]
        string Nome,
        string? Descricao,
        string? LinkFoto,
        int? Tipo,
        List<AlbumInputDto>? Albuns
    );

    public record ArtistaOutputDto(
        Guid Id,
        string Nome,
        string Descricao,
        string LinkFoto,
        string Tipo,
        List<AlbumOutputDto> Albuns
    );
}