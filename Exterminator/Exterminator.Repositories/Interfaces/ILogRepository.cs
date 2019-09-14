using System.Collections.Generic;
using Exterminator.Models;
using Exterminator.Models.Dtos;

namespace Exterminator.Repositories.Interfaces
{
    public interface ILogRepository
    {
         void LogToDatabase(ExceptionModel exception);
         // TODO: Should contain a method which retrieves all logs (LogDto) ordered by timestamp (descending)
    }
}