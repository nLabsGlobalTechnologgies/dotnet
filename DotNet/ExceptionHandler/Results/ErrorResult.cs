using Newtonsoft.Json;

namespace ExceptionHandler.Results;

public class ErrorResult
{
    public ErrorResult(string message)
    {
        Message = message;
    }
    public string Message { get; private set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}
