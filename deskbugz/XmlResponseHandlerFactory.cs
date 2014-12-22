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
            
            if(action == ApiActions.LOGON)
            {
                responseHandler = new LogonResponseHandler();
            }
            else if(action == ApiActions.LIST_FILTERS)
            {
                responseHandler = new ListFiltersXMLResponseHandler();
            }


            return responseHandler;
        }
    }
}
