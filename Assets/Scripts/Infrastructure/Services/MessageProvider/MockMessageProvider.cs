using System.Collections.Generic;

namespace Infrastructure.Services.MessageProvider {
    public sealed class MockMessageProvider : IMessageProvider {
        public List<MessageDescription> GetMessages() {
            var result = new List<MessageDescription>() {
                new MessageDescription()
                {
                    Id = 1,
                    Sender = "Sender1",
                    Message =  "text test text test ///",
                },
                new MessageDescription()
                {
                    Id = 2,
                    Sender = "Sender2",
                    Message =  "text test text test /// hey hey hey hey hey",
                },
                new MessageDescription()
                {
                    Id = 3,
                    Sender = "Sender5",
                    Message =  "text test text test /// text ... 222 333 444",
                },
            };

            return result;
        }
    }
}