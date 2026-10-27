namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Liên kết giữa đầu sách và thể loại.
/// </summary>
public class BookCategory
{
    /// <summary>
    /// Mã đầu sách.
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// Mã thể loại.
    /// </summary>
    public int CategoryId { get; set; }
}
