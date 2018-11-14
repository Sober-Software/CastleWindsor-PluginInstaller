using System.Collections.Generic;

namespace ServiceBackend.Implementation.DataType
{
    public class SuccessfulResponse : BusinessResponse
    {
        public SuccessfulResponse(IEnumerable<string> messages)
        {
            Success = true;
            Messages = messages;
        }
    }
}