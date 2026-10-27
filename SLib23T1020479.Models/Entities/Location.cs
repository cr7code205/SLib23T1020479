namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Vị trí lưu trữ sách trong thư viện.
/// </summary>
public class Location
{
    /// <summary>
    /// Mã định danh vị trí.
    /// </summary>
    public int LocationId { get; set; }

    /// <summary>
    /// Mã vị trí.
    /// </summary>
    public string LocationCode { get; set; } = string.Empty;

    /// <summary>
    /// Tên vị trí.
    /// </summary>
    public string LocationName { get; set; } = string.Empty;

    /// <summary>
    /// Tầng.
    /// </summary>
    public string? Floor { get; set; }

    /// <summary>
    /// Phòng.
    /// </summary>
    public string? Room { get; set; }

    /// <summary>
    /// Kệ sách.
    /// </summary>
    public string? Shelf { get; set; }

    /// <summary>
    /// Mô tả vị trí.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Trạng thái hoạt động của vị trí.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
