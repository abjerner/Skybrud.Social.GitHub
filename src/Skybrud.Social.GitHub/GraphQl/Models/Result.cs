namespace Skybrud.Social.GitHub.GraphQl.Models {

    public class Result {

        public object Data { get; }

        public Result(object data) {
            Data = data;
        }

        public static Result<T> Create<T>(T data) {
            return new (data);
        }

    }

    public class Result<T> : Result {

        public new T Data { get; }
        
        public Result(T data) : base(data) {
            Data = data;
        }

    }

}