using FirstService.Dtos;
using System.Threading.Tasks;

namespace FirstService.SyncDataServices.Http
{
    public interface ISecondDataClient
    {
        Task SendFirstToCommand(PlatformReadDto platform);
    }
}
