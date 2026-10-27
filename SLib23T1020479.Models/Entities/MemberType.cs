namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Loại bạn đọc và các giới hạn mượn tương ứng.
/// </summary>
public class MemberType
{
    /// <summary>
    /// Mã định danh loại bạn đọc.
    /// </summary>
    public int MemberTypeId { get; set; }

    /// <summary>
    /// Tên loại bạn đọc.
    /// </summary>
    public string TypeName { get; set; } = string.Empty;

    /// <summary>
    /// Số bản sao được mượn đồng thời tối đa.
    /// </summary>
    public int MaxActiveLoans { get; set; } = 3;

    /// <summary>
    /// Số ngày mượn tiêu chuẩn.
    /// </summary>
    public int LoanPeriodDays { get; set; } = 14;

    /// <summary>
    /// Số lần gia hạn tối đa.
    /// </summary>
    public int MaxRenewals { get; set; } = 0;

    /// <summary>
    /// Trạng thái hoạt động của loại bạn đọc.
    /// </summary>
    public bool IsActive { get; set; } = true;
}
