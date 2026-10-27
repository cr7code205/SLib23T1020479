namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Liên kết giữa đầu sách và tác giả.
/// </summary>
public class BookAuthor
{
    /// <summary>
    /// Mã đầu sách.
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// Mã tác giả.
    /// </summary>
    public int AuthorId { get; set; }

    /// <summary>
    /// Thứ tự hiển thị tác giả.
    /// </summary>
    public short AuthorOrder { get; set; } = 1;

    /// <summary>
    /// Vai trò hoặc đóng góp của tác giả.
    /// </summary>
    public string? Contribution { get; set; }
}
