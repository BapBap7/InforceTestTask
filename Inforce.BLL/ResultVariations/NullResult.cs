using FluentResults;

namespace Inforce.BLL.ResultVariations;

public class NullResult<T> : Result<T>
{
    public NullResult()
        : base()
    {
    }
}