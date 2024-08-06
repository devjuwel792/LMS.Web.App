namespace LMS.Application.Service
{
    public interface IUserService
    {
        string? GetUserId();
        bool? IsAuthenticated();
    }
}