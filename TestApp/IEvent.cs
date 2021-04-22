using System.Collections.Generic;

namespace TestApp
{
    public interface IEvent
    {
        IReadOnlyList<string> ViewId { get; }
    }
}