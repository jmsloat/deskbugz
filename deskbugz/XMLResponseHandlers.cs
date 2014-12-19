using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace deskbugz
{
    public interface IXMLResponseHandler
    {
        XmlResponsePacket handle(XmlDocument doc);
    }

    //base class for API response packets - should never be used alone
    public class XmlResponsePacket
    {
        string errorDescription;
        string errorCode;
    }

    public enum ApiActions
    {
        LOGON,
        LIST_FILTERS
    }
    
    public class LogonResponseHandler : IXMLResponseHandler
    {
        public LogonResponsePacket handle(XmlDocument doc)
        {
            string errorCode; // numerical error code returned from the API
            string errorDescription; // Plain-text error description given by the fogbugz api
            string token; //api token supplied by the FogBugz api

            //API will return a token if successful,  an error code if unsuccessful.
            XmlNodeList errNode = doc.GetElementsByTagName("error");
            System.Console.WriteLine(doc.ToString());
            if (errNode.Count > 0)
            {
                //FIXME: Different error codes will require different handling ( multiple users, incorrect password, etc. )
                //Should look for these at some point in the future. 
                errorCode = errNode[0].Name;
                errorDescription = errNode[0].Value;

                //return false;
            }

            XmlNode tokenNode = doc.SelectSingleNode("//token");
            //            XmlNode tokenNode = tokenNodes[0];
            if (tokenNode.NodeType != XmlNodeType.CDATA)
            {
                XmlNode childNode = tokenNode.FirstChild;
                token = childNode.Value;
            }
            else
            {
                token = tokenNode.Value;
            }

            Properties.Settings.Default.token = token;
            //Properties.Settings.Default.site = fbUrl;
            Properties.Settings.Default.Save();

            return new XmlResponsePacket();
        }
    }

    public class LogonResponsePacket : XmlResponsePacket
    {
        string apiToken;
    }
}
