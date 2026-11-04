namespace EventManagment.Dtos
{
    public record EventInfoDto(
        Guid Id,
        string Title,
        string? Description,
        DateTime StartAt,
        DateTime EndAt
    );
}
