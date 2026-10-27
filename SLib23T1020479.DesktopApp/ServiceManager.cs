using SLib23T1020479.BusinessLayer;
using SLib23T1020479.DataLayer;

namespace SLib23T1020479.DesktopApp; 
/// <summary>
/// Nơi giao tiếp với 
/// </summary>
public static class ServiceManager
{
    private static AuthorService _authorService;
    private static CategoryService _categoryService;
    private static LanguageService _languageService;
    private static LocationService _locationService;
    private static MemberTypeService _memberTypeService;
    private static PublisherService _publisherService;

///
/// khởi tạo các đối tượng Service
/// <pram name="connectionString"></pram>
  
 public static void Initialize(string connectionString)
    {
        _authorService = new AuthorService(new AuthorRepository(connectionString));
        _categoryService = new CategoryService(new CategoryRepository(connectionString));
        _languageService = new LanguageService(new LanguageRepository(connectionString));
        _locationService = new LocationService(new LocationRepository(connectionString));
        _memberTypeService = new MemberTypeService(new MemberTypeRepository(connectionString));
        _publisherService = new PublisherService(new PublisherRepository(connectionString));

    }

    public static AuthorService AuthorService => _authorService;
    public static CategoryService CategoryService => _categoryService;
    public static LanguageService LanguageService => _languageService;
    public static LocationService LocationService => _locationService;
    public static MemberTypeService MemberTypeService => _memberTypeService;
    public static PublisherService PublisherService => _publisherService;


}
