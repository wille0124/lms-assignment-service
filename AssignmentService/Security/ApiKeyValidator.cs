namespace AssignmentService.Security;

public static class ApiKeyValidator
{
    public static bool IsValid(
        HttpRequest request,
        IConfiguration configuration)
    {
        var expectedApiKey = configuration["ApiKey"];

        if (string.IsNullOrWhiteSpace(expectedApiKey))
        {
            return false;
        }

        if (!request.Headers.TryGetValue("X-API-Key", out var providedApiKey))
        {
            return false;
        }

        return providedApiKey.ToString() == expectedApiKey;
    }
}