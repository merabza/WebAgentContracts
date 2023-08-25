using System.Threading.Tasks;

namespace WebAgentMessagesContracts;

public interface IMessagesDataManager
{
    Task SendMessage(string? userName, string message);
    void UserConnected(string connectionId, string userName);
    void UserDisconnected(string connectionId, string userName);
}