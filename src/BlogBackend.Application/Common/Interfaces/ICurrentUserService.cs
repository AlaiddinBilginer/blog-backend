namespace BlogBackend.Application.Common.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
    string IpAddress { get; }
}
