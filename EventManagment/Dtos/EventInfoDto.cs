namespace EventManagment.Dtos
{
    public record EventInfoDto(
        string Id,
        string Title,
        string? Description,
        DateTime StartAt,
        DateTime EndAt
    );
}
