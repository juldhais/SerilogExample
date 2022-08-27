namespace SerilogExample.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public void Create(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Username))
        {
            _logger.LogError("Create new user | Username cannot be empty.");
            throw new BadHttpRequestException("Username cannot be empty");
        }
        
        _logger.LogInformation("Create new user | {username}", user.Username);
    }
}

public interface IUserService
{
    void Create(User user);
}

public class User
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}