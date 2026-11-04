namespace EventManagment.Dtos
{
    public record EventDto(
        string Id,
        string Title,
        string? Description,
        DateTime StartAt,
        DateTime EndAt
    );
}
