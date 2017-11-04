using System.Collections.Generic;
using DMG.Models;

namespace DMG.Business.Mappers
{
    public interface IMapper<TInput,TOutput>
    {
        TOutput Map(TInput billdto);
        IEnumerable<TOutput> Map(IEnumerable<TInput> inputs);
    }
}