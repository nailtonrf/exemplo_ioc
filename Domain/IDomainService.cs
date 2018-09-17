using Core;

namespace Domain
{
    public interface IDomainService
    {
        string GetUserFromHost();
    }

    public class DomainService : IDomainService
    {
        private readonly IUserContext _userContext;

        public DomainService(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public string GetUserFromHost()
        {
            return _userContext.Nome;
        }
    }
}