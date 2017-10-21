using System.Collections.Generic;
using DMG.Model;

namespace DMG.Business.Mappers
{
    public interface IMapper<TInput,TOutput>
    {
        TOutput Map(TInput input);
        IEnumerable<TOutput> Map(IEnumerable<TInput> inputs);
    }
}