using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace TestMediatR.Features
{
    public class TestGenericNotification<T> : INotification
    {
        public readonly T Value;
        public TestGenericNotification(T value) => Value = value;
    }

    public class TestGenericNotificationHandler<T> : INotificationHandler<TestGenericNotification<T>>
    {
        private readonly ILogger<TestGenericNotificationHandler<T>> _logger;

        public TestGenericNotificationHandler(ILogger<TestGenericNotificationHandler<T>> logger)
            => _logger = logger;

        public async Task Handle(TestGenericNotification<T> notification, CancellationToken cancellationToken)
        {
            if (notification is null)
                throw new ArgumentNullException(nameof(notification));
            if (notification.Value is null)
                throw new ArgumentNullException(nameof(notification.Value));

            _logger.LogInformation($"Notification value: {notification.Value.ToString()}");
        }
    }

    public class AnotherTestGenericNotificationHandler<T> : INotificationHandler<TestGenericNotification<T>>
    {
        private readonly ILogger<AnotherTestGenericNotificationHandler<T>> _logger;

        public AnotherTestGenericNotificationHandler(ILogger<AnotherTestGenericNotificationHandler<T>> logger)
            => _logger = logger;

        public async Task Handle(TestGenericNotification<T> notification, CancellationToken cancellationToken)
        {
            if (notification is null)
                throw new ArgumentNullException(nameof(notification));
            if (notification.Value is null)
                throw new ArgumentNullException(nameof(notification.Value));

            _logger.LogInformation($"Notification value: {notification.Value.ToString()}");
        }
    }
}
