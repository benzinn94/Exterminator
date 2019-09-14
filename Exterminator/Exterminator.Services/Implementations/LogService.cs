using System.Collections.Generic;
using Exterminator.Models;
using Exterminator.Models.Dtos;
using Exterminator.Repositories.Interfaces;
using Exterminator.Services.Interfaces;

namespace Exterminator.Services.Implementations
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void LogToDatabase(ExceptionModel exception)
        {
            _logRepository.LogToDatabase(exception);
        }
        // TODO: Should contain a method which retrieves all logs (LogDto) ordered by timestamp (descending)
    }
}