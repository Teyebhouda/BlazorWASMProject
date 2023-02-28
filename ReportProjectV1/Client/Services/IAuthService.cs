using ReportProjectV1.Shared.Models;

namespace ReportProjectV1.Client.Services
{
    public interface IAuthService
    {
       void login(User user);
    }
}
