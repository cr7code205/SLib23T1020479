namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Thông tin bạn đọc của thư viện.
/// </summary>
public class Member
{
    /// <summary>
    /// Mã định danh bạn đọc.
    /// </summary>
    public int MemberId { get; set; }

    /// <summary>
    /// Mã bạn đọc.
    /// </summary>
    public string MemberCode { get; set; } = string.Empty;

    /// <summary>
    /// Mã loại bạn đọc.
    /// </summary>
    public int MemberTypeId { get; set; }

    /// <summary>
    /// Họ và tên bạn đọc.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Ngày sinh bạn đọc.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Giới tính: Male, Female hoặc Other.
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// Địa chỉ email.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Số điện thoại.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Địa chỉ liên hệ.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Cơ quan hoặc tổ chức.
    /// </summary>
    public string? Organization { get; set; }

    /// <summary>
    /// Thời điểm đăng ký.
    /// </summary>
    public DateTime RegisteredAt { get; set; }

    /// <summary>
    /// Ngày hết hạn thẻ bạn đọc.
    /// </summary>
    public DateTime? ExpiredAt { get; set; }

    /// <summary>
    /// Trạng thái bạn đọc: Active, Suspended, Expired hoặc Closed.
    /// </summary>
    public string MemberStatus { get; set; } = "Active";

    /// <summary>
    /// Ghi chú về bạn đọc.
    /// </summary>
    public string? Notes { get; set; }
}
