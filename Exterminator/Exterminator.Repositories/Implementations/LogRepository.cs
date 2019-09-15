using System;
using System.Collections.Generic;
using System.Linq;
using Exterminator.Models;
using Exterminator.Models.Dtos;
using Exterminator.Models.Entities;
using Exterminator.Repositories.Data;
using Exterminator.Repositories.Interfaces;

namespace Exterminator.Repositories.Implementations
{
    public class LogRepository : ILogRepository
    {
        private readonly LogDbContext _dbContext = new LogDbContext();

        public void LogToDatabase(ExceptionModel exception)
        {
            _dbContext.Logs.Add(new Log
            {
                ExceptionMessage = exception.ExceptionMessage,
                StackTrace = exception.StackTrace,
                Timestamp = DateTime.Now
            });
            _dbContext.SaveChanges();
        }

        public List<LogDto> GetAllLogs(){
            var allLogsEntities = _dbContext.Logs.ToList();
            var allLogsDtos = new List<LogDto>();

            foreach(var log in allLogsEntities){
                allLogsDtos.Add(new LogDto{
                    Id = log.Id,
                    ExceptionMessage = log.ExceptionMessage,
                    StackTrace = log.StackTrace,
                    Timestamp = log.Timestamp
                });
            }

            return allLogsDtos.OrderBy(l => l.Timestamp).ToList();
        }
    }
}