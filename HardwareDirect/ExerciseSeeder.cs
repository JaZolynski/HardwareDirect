using HardwareDirect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareDirect
{
    public class ExerciseSeeder
    {
        private readonly ExerciseDbContext _dbContext;
        public ExerciseSeeder (ExerciseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Positions.Any())
                {
                    var positions = GetPositions();
                    _dbContext.Positions.AddRange(positions);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Employees.Any())
                {
                    var employees = GetEmployees();
                    _dbContext.Employees.AddRange(employees);
                    _dbContext.SaveChanges();
                }
            }
        }

        public List<Position> GetPositions()
        {
            List<Position> positions = new List<Position>()
            {
             new Position { Name = "PROGRAMISTA" },
             new Position { Name = "QA" },
             new Position { Name = "PROJECT MANAGER" }
            };
            return positions;
        }

        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee { Name = "Jan", Surname = "Kowalski", EMail = "jkowalski@example.com", PositionId = 1 },
                new Employee { Name = "Anna", Surname = "Nowak", EMail = "anowak@example.com", PositionId = 2 },
                new Employee { Name = "Piotr", Surname = "Czerwony", EMail = "pczerwony@example.com", PositionId = 3 }
            };

            return employees;
        }
    }
}
