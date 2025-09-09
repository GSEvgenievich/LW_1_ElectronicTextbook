using Microsoft.EntityFrameworkCore;
using ServiceLayer.Data;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    public class TestService
    {
        public static readonly ElectronicTextbookContext _context = new();

        public async Task<Test> GetTestByIdAsync(int testId)
        {
            return await _context.Tests.Include(t => t.Questions).ThenInclude(q => q.Answers).FirstOrDefaultAsync(t => t.TestId == testId);
        }

        public async Task<string> GetTestNameAsync(Test test)
        {
            return "Тест по лекции: " + (await _context.Lections.FirstOrDefaultAsync(l => l.LectionId == test.LectionId)).LectionName;
        }
    }
}
