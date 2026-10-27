namespace SLib23T1020479.Models.Constants;

/// <summary>
/// Chứa các hằng số biểu diễn những giá trị hợp lệ của các cột
/// được giới hạn bằng CHECK constraint trong cơ sở dữ liệu LibraryManagementDB.
/// </summary>
public static class DatabaseConstant
{
    #region BookCopies - Condition

    /// <summary>
    /// Tình trạng bản sao sách là mới.
    /// </summary>
    public const string BOOKCOPIES_CONDITION_NEW = "New";

    /// <summary>
    /// Tình trạng bản sao sách là tốt.
    /// </summary>
    public const string BOOKCOPIES_CONDITION_GOOD = "Good";

    /// <summary>
    /// Tình trạng bản sao sách là trung bình.
    /// </summary>
    public const string BOOKCOPIES_CONDITION_FAIR = "Fair";

    /// <summary>
    /// Tình trạng bản sao sách là hư hỏng.
    /// </summary>
    public const string BOOKCOPIES_CONDITION_DAMAGED = "Damaged";

    #endregion

    #region BookCopies - Status

    /// <summary>
    /// Trạng thái bản sao sách là có sẵn để cho mượn.
    /// </summary>
    public const string BOOKCOPIES_STATUS_AVAILABLE = "Available";

    /// <summary>
    /// Trạng thái bản sao sách là đang được cho mượn.
    /// </summary>
    public const string BOOKCOPIES_STATUS_ONLOAN = "OnLoan";

    /// <summary>
    /// Trạng thái bản sao sách là đã được đặt trước.
    /// </summary>
    public const string BOOKCOPIES_STATUS_RESERVED = "Reserved";

    /// <summary>
    /// Trạng thái bản sao sách là bị mất.
    /// </summary>
    public const string BOOKCOPIES_STATUS_LOST = "Lost";

    /// <summary>
    /// Trạng thái bản sao sách là đã thanh lý hoặc ngừng sử dụng.
    /// </summary>
    public const string BOOKCOPIES_STATUS_WITHDRAWN = "Withdrawn";

    #endregion

    #region Members - Gender

    /// <summary>
    /// Giới tính hội viên là nam.
    /// </summary>
    public const string MEMBERS_GENDER_MALE = "Male";

    /// <summary>
    /// Giới tính hội viên là nữ.
    /// </summary>
    public const string MEMBERS_GENDER_FEMALE = "Female";

    /// <summary>
    /// Giới tính hội viên là giới tính khác.
    /// </summary>
    public const string MEMBERS_GENDER_OTHER = "Other";

    #endregion

    #region Members - Status

    /// <summary>
    /// Trạng thái hội viên đang hoạt động.
    /// </summary>
    public const string MEMBERS_STATUS_ACTIVE = "Active";

    /// <summary>
    /// Trạng thái hội viên đang bị tạm đình chỉ.
    /// </summary>
    public const string MEMBERS_STATUS_SUSPENDED = "Suspended";

    /// <summary>
    /// Trạng thái hội viên đã hết hạn.
    /// </summary>
    public const string MEMBERS_STATUS_EXPIRED = "Expired";

    /// <summary>
    /// Trạng thái hội viên đã đóng hoặc chấm dứt tư cách hội viên.
    /// </summary>
    public const string MEMBERS_STATUS_CLOSED = "Closed";

    #endregion

    #region Loans - Status

    /// <summary>
    /// Trạng thái phiếu mượn đang hoạt động, chưa hoàn tất hoặc hủy.
    /// </summary>
    public const string LOANS_STATUS_ACTIVE = "Active";

    /// <summary>
    /// Trạng thái phiếu mượn đã hoàn tất.
    /// </summary>
    public const string LOANS_STATUS_COMPLETED = "Completed";

    /// <summary>
    /// Trạng thái phiếu mượn đã bị hủy.
    /// </summary>
    public const string LOANS_STATUS_CANCELLED = "Cancelled";

    #endregion

    #region LoanItems - Status

    /// <summary>
    /// Trạng thái chi tiết mượn là đang mượn, chưa trả.
    /// </summary>
    public const string LOANITEMS_STATUS_BORROWED = "Borrowed";

    /// <summary>
    /// Trạng thái chi tiết mượn là đã trả sách.
    /// </summary>
    public const string LOANITEMS_STATUS_RETURNED = "Returned";

    /// <summary>
    /// Trạng thái chi tiết mượn là sách bị mất.
    /// </summary>
    public const string LOANITEMS_STATUS_LOST = "Lost";

    #endregion

    #region LoanItems - ReturnCondition

    /// <summary>
    /// Tình trạng sách khi trả là mới.
    /// </summary>
    public const string LOANITEMS_RETURNCONDITION_NEW = "New";

    /// <summary>
    /// Tình trạng sách khi trả là tốt.
    /// </summary>
    public const string LOANITEMS_RETURNCONDITION_GOOD = "Good";

    /// <summary>
    /// Tình trạng sách khi trả là trung bình.
    /// </summary>
    public const string LOANITEMS_RETURNCONDITION_FAIR = "Fair";

    /// <summary>
    /// Tình trạng sách khi trả là hư hỏng.
    /// </summary>
    public const string LOANITEMS_RETURNCONDITION_DAMAGED = "Damaged";

    #endregion
}