namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Nhà xuất bản.
/// </summary>
public class Publisher
{
    /// <summary>
    /// Mã định danh nhà xuất bản.
    /// </summary>
    public int PublisherId { get; set; }

    /// <summary>
    /// Tên nhà xuất bản.
    /// </summary>
    public string PublisherName { get; set; } = string.Empty;

    /// <summary>
    /// Địa chỉ nhà xuất bản.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Số điện thoại nhà xuất bản.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Địa chỉ email nhà xuất bản.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Địa chỉ website nhà xuất bản.
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// Trạng thái hoạt động của nhà xuất bản.
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// Thời điểm tạo bản ghi.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
