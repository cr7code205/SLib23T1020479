namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Một dòng chi tiết sách trong phiếu mượn.
/// </summary>
public class LoanItem
{
    /// <summary>
    /// Mã định danh chi tiết phiếu mượn.
    /// </summary>
    public int LoanItemId { get; set; }

    /// <summary>
    /// Mã phiếu mượn.
    /// </summary>
    public int LoanId { get; set; }

    /// <summary>
    /// Mã bản sao được mượn.
    /// </summary>
    public int BookCopyId { get; set; }

    /// <summary>
    /// Thời điểm phải trả sách.
    /// </summary>
    public DateTime DueAt { get; set; }

    /// <summary>
    /// Thời điểm trả sách; null khi chưa trả.
    /// </summary>
    public DateTime? ReturnedAt { get; set; }

    /// <summary>
    /// Trạng thái chi tiết: Borrowed, Returned hoặc Lost.
    /// </summary>
    public string ItemStatus { get; set; } = "Borrowed";

    /// <summary>
    /// Tình trạng bản sao khi trả: New, Good, Fair hoặc Damaged.
    /// </summary>
    public string? ReturnCondition { get; set; }

    /// <summary>
    /// Ghi chú chi tiết mượn trả.
    /// </summary>
    public string? Notes { get; set; }
}
