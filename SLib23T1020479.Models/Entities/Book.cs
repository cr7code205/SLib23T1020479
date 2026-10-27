namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Thông tin thư mục của một đầu sách.
/// </summary>
public class Book
{
    /// <summary>
    /// Mã định danh đầu sách.
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// Mã ISBN của sách.
    /// </summary>
    public string? ISBN { get; set; }

    /// <summary>
    /// Nhan đề sách.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Nhan đề phụ của sách.
    /// </summary>
    public string? Subtitle { get; set; }

    /// <summary>
    /// Mã nhà xuất bản.
    /// </summary>
    public int? PublisherId { get; set; }

    /// <summary>
    /// Mã ngôn ngữ.
    /// </summary>
    public int? LanguageId { get; set; }

    /// <summary>
    /// Năm xuất bản.
    /// </summary>
    public short? PublicationYear { get; set; }

    /// <summary>
    /// Thông tin lần xuất bản.
    /// </summary>
    public string? Edition { get; set; }

    /// <summary>
    /// Mô tả nội dung sách.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Số trang.
    /// </summary>
    public int? PageCount { get; set; }

    /// <summary>
    /// Đường dẫn ảnh bìa.
    /// </summary>
    public string? CoverImagePath { get; set; }

    /// <summary>
    /// Trạng thái hoạt động của đầu sách.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Thời điểm tạo bản ghi.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Thời điểm cập nhật gần nhất.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
