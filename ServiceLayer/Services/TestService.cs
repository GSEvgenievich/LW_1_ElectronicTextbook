﻿using Microsoft.EntityFrameworkCore;
using ServiceLayer.Data;
using ServiceLayer.Models;

namespace ServiceLayer.Services
{
    public class TestService
    {
        public static readonly ElectronicTextbookContext _context = new();

        public async Task<Test> GetTestByLectionIdAsync(int lectionId)
        {
            return await _context.Tests.Include(t => t.Lection).Include(t => t.Questions).ThenInclude(q => q.Answers).FirstOrDefaultAsync(t => t.LectionId == lectionId);
        }

        public async Task<string> GetTestNameAsync(Test test)
        {
            return "Тест по лекции: " + (await _context.Lections.FirstOrDefaultAsync(l => l.LectionId == test.LectionId)).LectionName;
        }

        public async Task<List<Question>> GetQuestionsWithResults(int testId, int userId)
        {
            return await _context.Questions
                .Where(q => q.TestId == testId)
                .Include(q => q.QuestionsResults
                .Where(qr => qr.UserId == userId))
                .ToListAsync();
        }
    }
}
