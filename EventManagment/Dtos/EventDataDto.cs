using System.ComponentModel.DataAnnotations;

namespace EventManagment.Dtos
{
    public record EventDataDto(
        [Required(ErrorMessage = "У события должно быть название Title")]
        string? Title,
        string? Description,
        [Required(ErrorMessage = "У события должна быть дата начала StartAt")]
        DateTime? StartAt,
        [Required(ErrorMessage = "У события должно быть дата окончания EndAt")]
        DateTime? EndAt
    );
}
