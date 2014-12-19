using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deskbugz
{
    public static class XmlResponseHandlerFactory
    {
        public static IXMLResponseHandler Create(ApiActions action)
        {
            IXMLResponseHandler responseHandler = null;
            try
            {
                if(action == ApiActions.LOGON)
                {
                    responseHandler = new LogonResponseHandler();
                }


                return responseHandler;
            }
            catch(ArgumentException)
            {
                Console.Error.WriteLine("Invalid action supplied to XMLResponseHandlerFactory");
                return null;
            }
        }
    }
}
