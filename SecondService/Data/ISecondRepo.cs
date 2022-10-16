using SecondService.Models;
using System.Collections;
using System.Collections.Generic;

namespace SecondService.Data
{
    public interface ISecondRepo
    {
        //Platforms 
        bool SaveChanges();
        IEnumerable<Platform> GetAllFirsts();
        void CreateFirst(Platform first);
        bool FirstExist(int firstId);

        //Seconds
        IEnumerable<Second> GetSecondsForPlatform(int firstId);
        Second GetSecond(int firstId, int secondId);
        void CreateSecond(int firstId, Second second);

    }
}
