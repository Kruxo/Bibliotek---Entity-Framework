namespace Labb_2.DTO;

public class AddBookDTO
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public DateOnly Published { get; set; }
    public int? Rating { get; set; }
}
