namespace CleanArchAndCQRS.Application.DTO
{
    public record PackingItemDto
    {
        public string Name { get; set; }
        public uint Quantity { get; set; }
        public bool IsPacked { get; set; }
    }
}
    