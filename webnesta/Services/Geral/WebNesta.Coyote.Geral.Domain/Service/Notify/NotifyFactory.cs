using WebNesta.Coyote.Core.Contracts;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public static class NotifyFactory
    {
        public static T Create<T>() where T : IDomainNotifyService, new()
        {
            return new T();
        }
    }
}
