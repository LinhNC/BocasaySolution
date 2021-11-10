using System.Collections.Generic;

namespace Application.Wrappers
{
    public class Result<T> : IResult<T>
    {
        public T Data { get; set; }
        public List<string> Messages { get; set; } = new List<string>();

        public bool Succeeded { get; set; }

        public static Result<T> Fail(string message)
        {
            return new Result<T> { Succeeded = false, Messages = new List<string> { message } };
        }
        public static Result<T> Fail(List<string> messages)
        {
            return new Result<T> { Succeeded = false, Messages = messages };
        }
        public static Result<T> Success()
        {
            return new Result<T> { Succeeded = true };
        }
        public static Result<T> Success(string message)
        {
            return new Result<T> { Succeeded = true, Messages = new List<string> { message } };
        }
        public static Result<T> Success(T data, string message)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = new List<string> { message } };
        }

        public static Result<T> Success(T data, List<string> messages)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = messages };
        }

    }
}
