using SLib23T1020479.DataLayer;
using SLib23T1020479.Models.Entities;

namespace SLib23T1020479.BusinessLayer;

/// <summary>
/// Cung cấp các chức năng nghiệp vụ quản lý loại độc giả.
/// </summary>
public class MemberTypeService
{
    private readonly MemberTypeRepository _memberTypeRepository;

    /// <summary>
    /// Khởi tạo MemberTypeService với MemberTypeRepository.
    /// </summary>
    public MemberTypeService(MemberTypeRepository memberTypeRepository)
    {
        _memberTypeRepository = memberTypeRepository
            ?? throw new Exception("MemberTypeRepository không được null.");
    }

    /// <summary>
    /// Lấy danh sách loại độc giả.
    /// </summary>
    public async Task<List<MemberType>> ListAsync()
    {
        return await _memberTypeRepository.ListAsync();
    }

    /// <summary>
    /// Lấy thông tin loại độc giả theo mã.
    /// </summary>
    public async Task<MemberType> GetAsync(int memberTypeId)
    {
        if (memberTypeId <= 0)
            throw new Exception("Mã loại độc giả phải lớn hơn 0.");

        var memberType = await _memberTypeRepository.GetAsync(memberTypeId);
        if (memberType == null)
            throw new Exception("Không tìm thấy loại độc giả.");

        return memberType;
    }

    /// <summary>
    /// Thêm loại độc giả mới và trả về mã vừa tạo.
    /// </summary>
    public async Task<int> AddAsync(MemberType memberType)
    {
        ValidateMemberType(memberType);
        return await _memberTypeRepository.AddAsync(memberType);
    }

    /// <summary>
    /// Cập nhật thông tin loại độc giả.
    /// </summary>
    public async Task<bool> UpdateAsync(MemberType memberType)
    {
        ValidateMemberType(memberType);

        if (memberType.MemberTypeId <= 0)
            throw new Exception("Mã loại độc giả phải lớn hơn 0.");

        return await _memberTypeRepository.UpdateAsync(memberType);
    }

    /// <summary>
    /// Xóa loại độc giả nếu không được độc giả nào sử dụng.
    /// </summary>
    public async Task<bool> DeleteAsync(int memberTypeId)
    {
        if (memberTypeId <= 0)
            throw new Exception("Mã loại độc giả phải lớn hơn 0.");

        if (await _memberTypeRepository.InUsedAsync(memberTypeId))
            throw new Exception("Không thể xóa loại độc giả vì đang được độc giả tham chiếu.");

        return await _memberTypeRepository.DeleteAsync(memberTypeId);
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của dữ liệu loại độc giả
    /// </summary>
    private static void ValidateMemberType(MemberType memberType)
    {
        if (memberType == null)
            throw new Exception("Thông tin loại độc giả không được null.");

        if (string.IsNullOrWhiteSpace(memberType.TypeName))
            throw new Exception("Tên loại độc giả không được để trống.");

        if (memberType.MaxActiveLoans <= 0)
            throw new Exception("Số lượng sách được mượn tối đa phải lớn hơn 0.");

        if (memberType.LoanPeriodDays <= 0)
            throw new Exception("Số ngày mượn sách phải lớn hơn 0.");

        if (memberType.MaxRenewals < 0)
            throw new Exception("Số lần gia hạn tối đa không được âm.");
    }
}
