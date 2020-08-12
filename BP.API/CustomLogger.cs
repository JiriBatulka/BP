using Microsoft.Extensions.Logging;
using System;

namespace BP
{
    public class CustomLogger
    {
        private readonly ILogger _logger;

        public CustomLogger(ILogger<CustomLogger> logger)
        {
            _logger = logger;
        }

        public void LogApiException(Exception ex)
        {
            _logger.LogError(
                System.Environment.NewLine +
                "Message: {ExceptionMessage}" +
                System.Environment.NewLine +
                "Trace: {ExceptionTrace}" +
                System.Environment.NewLine +
                "Time: {ExceptionTime}",
                ex.Message, ex.StackTrace, DateTime.UtcNow);
        }
    }
}
