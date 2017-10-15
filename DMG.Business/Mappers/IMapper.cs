namespace DMG.Business.Mappers
{
    public interface IMapper<TInput,TOutput>
    {
        TOutput Map(TInput user);
    }
}