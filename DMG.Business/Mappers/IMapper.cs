using System.Collections.Generic;
using DMG.Model;

namespace DMG.Business.Mappers
{
    public interface IMapper<TInput,TOutput>
    {
        TOutput Map(TInput user);
        IEnumerable<TOutput> Map(IEnumerable<User> users);
    }
}