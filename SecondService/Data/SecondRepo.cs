using SecondService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondService.Data
{
    public class SecondRepo : ISecondRepo
    {
        private readonly AppDbContext _context;

        public SecondRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateSecond(int firstId, Second second)
        {
            if(second == null)
            {
                throw new ArgumentNullException(nameof(second));
            }
            second.PlatformId = firstId;
            _context.Seconds.Add(second);
        }

        public void CreateFirst(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _context.Platforms.Add(platform);

        }

        public IEnumerable<Platform> GetAllFirsts()
        {
            return _context.Platforms.ToList();
        }

        public Second GetSecond(int platformId, int secondId)
        {
            return _context.Seconds
                .Where(s => s.PlatformId == platformId && s.Id == secondId)
                .FirstOrDefault();
        }

        public IEnumerable<Second> GetSecondsForPlatform(int platformId)
        {
            return _context.Seconds
                .Where(s => s.PlatformId == platformId)
                .OrderBy(s => s.Platform.Name);
        }

        public bool FirstExist(int firstId)
        {
            return _context.Platforms.Any(p => p.Id == firstId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
