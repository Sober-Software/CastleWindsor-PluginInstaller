using System.Collections.Generic;

namespace ServiceBackend.Implementation.DataType
{
    public class UnsuccessfulResponse : BusinessResponse
    {
        public UnsuccessfulResponse(IEnumerable<string> messages)
        {
            Success = false;
            Messages = messages;
        }
    }
}