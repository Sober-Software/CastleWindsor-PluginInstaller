using System.Collections.Generic;

namespace ServiceBackend.Implementation.DataType
{
    public abstract class BusinessResponse
    {
        public IEnumerable<string> Messages { get; protected set; }

        public bool Success { get; protected set; }
    }
}