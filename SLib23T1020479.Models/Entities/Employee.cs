namespace SLib23T1020479.Models.Entities;

/// <summary>
/// Nhân viên thư viện.
/// </summary>
public class Employee
{
    /// <summary>
    /// Mã định danh nhân viên.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Tên nhân viên.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Họ và tên đệm của nhân viên.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Ngày sinh nhân viên.
    /// </summary>
    public DateTime? DateOfBirth { get; set; }

    /// <summary>
    /// Địa chỉ email nhân viên.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Số điện thoại nhân viên.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Địa chỉ nhân viên.
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// Mật khẩu theo cấu trúc CSDL hiện tại.
    /// </summary>
    public string? Password { get; set; }

    /// <summary>
    /// Trạng thái đang làm việc của nhân viên.
    /// </summary>
    public bool IsWorking { get; set; } = true;
}
