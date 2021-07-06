using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAccount.Common
{
    public class BaseResponse<T>
    {
        public StatusResponse status;
        public string message;
        public Object data;

        public BaseResponse(StatusResponse status, string message, Object data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}