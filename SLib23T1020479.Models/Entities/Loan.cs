namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Phiếu mượn của bạn đọc.
/// </summary>
public class Loan
{
    /// <summary>
    /// Mã định danh phiếu mượn.
    /// </summary>
    public int LoanId { get; set; }

    /// <summary>
    /// Mã phiếu mượn.
    /// </summary>
    public string LoanCode { get; set; } = string.Empty;

    /// <summary>
    /// Mã bạn đọc.
    /// </summary>
    public int MemberId { get; set; }

    /// <summary>
    /// Mã nhân viên xử lý; có thể null.
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// Thời điểm lập phiếu mượn.
    /// </summary>
    public DateTime BorrowedAt { get; set; }

    /// <summary>
    /// Trạng thái phiếu mượn: Active, Completed hoặc Cancelled.
    /// </summary>
    public string LoanStatus { get; set; } = "Active";

    /// <summary>
    /// Ghi chú phiếu mượn.
    /// </summary>
    public string? Notes { get; set; }
}
