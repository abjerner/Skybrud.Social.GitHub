#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Skybrud.Social.GitHub.GraphQl.Models;

public class Result {

    public object Data { get; }

    public Result(object data) {
        Data = data;
    }

    public static Result<T> Create<T>(T data) where T : notnull {
        return new Result<T>(data);
    }

}

public class Result<T> : Result where T : notnull {

    public new T Data { get; }

    public Result(T data) : base(data) {
        Data = data;
    }

}