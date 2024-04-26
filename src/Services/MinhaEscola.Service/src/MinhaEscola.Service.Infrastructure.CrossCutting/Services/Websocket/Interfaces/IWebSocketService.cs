namespace MinhaEscola.Service.Infrastructure.CrossCutting.Services.Websocket.Interfaces
{
    public interface IWebSocketService
    {
        Task SendMessage(ModelSendMessageWebSocket message);
    }
}
