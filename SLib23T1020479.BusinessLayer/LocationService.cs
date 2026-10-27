using SLib23T1020479.DataLayer;
using SLib23T1020479.Models.Entities;

namespace SLib23T1020479.BusinessLayer;

/// <summary>
/// Cung cấp các chức năng nghiệp vụ quản lý vị trí lưu trữ sách.
/// </summary>
public class LocationService
{
    private readonly LocationRepository _locationRepository;

    /// <summary>
    /// Khởi tạo LocationService với LocationRepository.
    /// </summary>
    public LocationService(LocationRepository locationRepository)
    {
        _locationRepository = locationRepository
            ?? throw new Exception("LocationRepository không được null.");
    }

    /// <summary>
    /// Lấy danh sách vị trí lưu trữ sách.
    /// </summary>
    public async Task<List<Location>> ListAsync()
    {
        return await _locationRepository.ListAsync();
    }

    /// <summary>
    /// Lấy thông tin vị trí lưu trữ sách theo mã.
    /// </summary>
    public async Task<Location> GetAsync(int locationId)
    {
        if (locationId <= 0)
            throw new Exception("Mã vị trí phải lớn hơn 0.");

        var location = await _locationRepository.GetAsync(locationId);
        if (location == null)
            throw new Exception("Không tìm thấy vị trí lưu trữ.");

        return location;
    }

    /// <summary>
    /// Thêm vị trí lưu trữ mới và trả về mã vừa tạo.
    /// </summary>
    public async Task<int> AddAsync(Location location)
    {
        ValidateLocation(location);
        return await _locationRepository.AddAsync(location);
    }

    /// <summary>
    /// Cập nhật thông tin vị trí lưu trữ.
    /// </summary>
    public async Task<bool> UpdateAsync(Location location)
    {
        ValidateLocation(location);

        if (location.LocationId <= 0)
            throw new Exception("Mã vị trí phải lớn hơn 0.");

        return await _locationRepository.UpdateAsync(location);
    }

    /// <summary>
    /// Xóa vị trí lưu trữ nếu không được bản sao sách tham chiếu.
    /// </summary>
    public async Task<bool> DeleteAsync(int locationId)
    {
        if (locationId <= 0)
            throw new Exception("Mã vị trí phải lớn hơn 0.");

        if (await _locationRepository.InUsedAsync(locationId))
            throw new Exception("Không thể xóa vị trí lưu trữ vì đang được bản sao sách tham chiếu.");

        return await _locationRepository.DeleteAsync(locationId);
    }

    /// <summary>
    /// Kiểm tra tính hợp lệ của dữ liệu vị trí lưu trữ sách
    /// </summary>
    private static void ValidateLocation(Location location)
    {
        if (location == null)
            throw new Exception("Thông tin vị trí lưu trữ không được null.");

        if (string.IsNullOrWhiteSpace(location.LocationCode))
            throw new Exception("Mã vị trí lưu trữ không được để trống.");

        if (string.IsNullOrWhiteSpace(location.LocationName))
            throw new Exception("Tên vị trí lưu trữ không được để trống.");
    }
}
