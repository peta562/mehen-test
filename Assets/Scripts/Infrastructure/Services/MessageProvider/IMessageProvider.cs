using System.Collections.Generic;

namespace Infrastructure.Services.MessageProvider {
    public interface IMessageProvider : IService {
        List<MessageDescription> GetMessages();
    }
}