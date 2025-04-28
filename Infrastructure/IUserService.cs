public interface IUserService
{
    Task<IActionResult> UpdateUserAsync(int id, User updatedUser);
}

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IFileUploadService _fileUploadService;
    private readonly ApplicationDbContext _context;

    public UserService(IUserRepository userRepository, IFileUploadService fileUploadService, ApplicationDbContext context)
    {
        _userRepository = userRepository;
        _fileUploadService = fileUploadService;
        _context = context;
    }

    public async Task<IActionResult> UpdateUserAsync(int id, User updatedUser)
    {
        if (updatedUser == null || id != updatedUser.Id)
        {
            return new BadRequestObjectResult("Dados de usuário inválidos ou ID incompatível.");
        }

        var existingUser = await _userRepository.GetByIdAsync(id);
        if (existingUser == null)
        {
            return new NotFoundObjectResult($"Usuário com ID {id} não encontrado.");
        }

        existingUser.Name = updatedUser.Name;
        existingUser.Email = updatedUser.Email;
        existingUser.Image = updatedUser.Image;

        await _userRepository.UpdateAsync(existingUser);

        return new NoContentResult();
    }
}
