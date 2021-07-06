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
        public List<T> data;
        public int numberOfPage;

        public BaseResponse(StatusResponse status, string message, List<T> data, int numberOfPage)
        {
            this.status = status;
            this.message = message;
            this.data = data;
            this.numberOfPage = numberOfPage;
        }
    }
}