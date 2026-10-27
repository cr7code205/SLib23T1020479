namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Một bản sao vật lý của đầu sách.
/// </summary>
public class BookCopy
{
    /// <summary>
    /// Mã định danh bản sao.
    /// </summary>
    public int BookCopyId { get; set; }

    /// <summary>
    /// Mã đầu sách.
    /// </summary>
    public int BookId { get; set; }

    /// <summary>
    /// Mã vạch của bản sao.
    /// </summary>
    public string Barcode { get; set; } = string.Empty;

    /// <summary>
    /// Mã vị trí lưu trữ.
    /// </summary>
    public int? LocationId { get; set; }

    /// <summary>
    /// Ngày tiếp nhận bản sao.
    /// </summary>
    public DateTime? AcquisitionDate { get; set; }

    /// <summary>
    /// Giá tiếp nhận bản sao.
    /// </summary>
    public decimal? AcquisitionPrice { get; set; }

    /// <summary>
    /// Tình trạng vật lý: New, Good, Fair hoặc Damaged.
    /// </summary>
    public string CopyCondition { get; set; } = "Good";

    /// <summary>
    /// Trạng thái bản sao: Available, OnLoan, Reserved, Lost hoặc Withdrawn.
    /// </summary>
    public string CopyStatus { get; set; } = "Available";

    /// <summary>
    /// Ghi chú về bản sao.
    /// </summary>
    public string? Notes { get; set; }
}
