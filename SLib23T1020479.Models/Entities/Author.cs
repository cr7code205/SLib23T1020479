namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Tác giả.
/// </summary>
public class Author
{
    /// <summary>
    /// Mã định danh tác giả.
    /// </summary>
    public int AuthorId { get; set; }

    /// <summary>
    /// Tên tác giả.
    /// </summary>
    public string AuthorName { get; set; } = string.Empty;

    /// <summary>
    /// Thông tin tiểu sử tác giả.
    /// </summary>
    public string? Biography { get; set; }

    /// <summary>
    /// Ngày sinh của tác giả.
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// Ngày mất của tác giả.
    /// </summary>
    public DateTime? DeathDate { get; set; }

    /// <summary>
    /// Trạng thái hoạt động của tác giả.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
