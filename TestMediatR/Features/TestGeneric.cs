using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestMediatR.Features
{
    public class TestGenericRequest<T> : IRequest<string>
    {
        public readonly T Value;
        public TestGenericRequest(T value) => Value = value;
    }

    public class TestGenericHandler<T> : IRequestHandler<TestGenericRequest<T>, string>
    {
        public async Task<string> Handle(TestGenericRequest<T> request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            if (request.Value is null)
                throw new ArgumentNullException(nameof(request.Value));

            return request.Value.ToString()!;
        }
    }
}
