using System.Threading.Tasks;

namespace WebAgentMessagesContracts;

public interface IMessenger
{
    Task SendMessage(string message);
}