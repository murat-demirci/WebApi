using System.Net;

namespace Core.ResultBases;
public sealed record ResultBase
{
    public bool IsSucceeded { get; init; }

    public ResultBase(){}
    public ResultBase(bool isSucceeded)
    {
        IsSucceeded = isSucceeded;
    }

}

public sealed record ResultBase<T>
{
    public bool IsSucceeded { get; init; } = false;
    public T? Data { get; init; }

    public ResultBase(){}
    public ResultBase(bool isSucceeded)
    {
        IsSucceeded = isSucceeded;
    }
    public ResultBase(bool isSucceeded, T data)
    {
        IsSucceeded = isSucceeded;
        Data = data;
    }
}
