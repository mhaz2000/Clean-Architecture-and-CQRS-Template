namespace CleanArchAndCQRS.Application.DTO
{
    public record PackingListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LocalizationDto Localization { get; set; }
        public IEnumerable<PackingItemDto> Items { get; set; }
    }
}
    