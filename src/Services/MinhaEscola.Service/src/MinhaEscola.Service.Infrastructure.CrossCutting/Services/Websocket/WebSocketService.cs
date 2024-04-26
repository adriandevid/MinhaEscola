using MinhaEscola.Service.Infrastructure.CrossCutting.Services.Websocket.Interfaces;
using System.Net.WebSockets;
using System.Text.Json;

namespace MinhaEscola.Service.Infrastructure.CrossCutting.Services.Websocket
{
    public class WebSocketService : IWebSocketService
    {
        private readonly ClientWebSocket _socket;

        public WebSocketService(ClientWebSocket socket)
        {
            _socket = socket;
        }

        public async Task SendMessage(ModelSendMessageWebSocket message)
        {
            await _socket.SendAsync(JsonSerializer.SerializeToUtf8Bytes(message), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
