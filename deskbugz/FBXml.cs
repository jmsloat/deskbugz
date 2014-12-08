using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace deskbugz
{
    public class FBXml
    {
        FBNet net = new FBNet();
        string token = "";
        string errCode = "";
        string errDesc = "";
        string fbUrl = "";
        List<Filter> currentFilters;
        public FBXml()
        {
            //FBNet net = new FBNet();
        }

        public delegate bool XMLResponse(XmlDocument response);

        public bool connect(string url, string user, string pass)
        {
            //Construct Fogbugz logon url - contains url, cmd descriptor, username, and password
            string realurl = url += "/api.asp?";
            fbUrl = url;
            Dictionary<string, string> args = new Dictionary<string, string>();
            args["cmd"] = "logon";
            args["email"] = user;
            args["password"] = pass;

            bool success = this.net.buildRequest(realurl, args, new XMLResponse(LogonResponseHandler));

            return success;
        }

        public List<Filter> getFilters()
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args["cmd"] = "listFilters";
            args["token"] = token;

            bool success = this.net.buildRequest(fbUrl, args, new XMLResponse(ListFiltersResponseHandler));

            return this.currentFilters;
        }

        private bool LogonResponseHandler(XmlDocument doc)
        {
            //API will return a token if successful,  an error code if unsuccessful.
            XmlNodeList errNode = doc.GetElementsByTagName("error");
            System.Console.WriteLine(doc.ToString());
            if (errNode.Count > 0)
            {
                //FIXME: Different error codes will require different handling ( multiple users, incorrect password, etc. )
                //Should look for these at some point in the future. 
                errCode = errNode[0].Name;
                errDesc = errNode[0].Value;

                return false;
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

            return true;
        }

        private bool ListFiltersResponseHandler(XmlDocument doc)
        {
            List<Filter> filterList = new List<Filter>();
            System.Console.WriteLine(doc.OuterXml);
            XmlNode errNode = doc.SelectSingleNode("//error");
            if (errNode != null)
            {
                errCode = errNode.Name;
                errDesc = errNode.Value;
                return false;
            }

            XmlNodeList filters = doc.SelectNodes("//filter");
            foreach(XmlNode filter in filters)
            {
                string filterType = "";
                string sFilter = "";
                foreach(XmlAttribute attr in filter.Attributes)
                {
                    if (attr.Name == "type")
                        filterType = attr.Value;
                    else if (attr.Name == "sFilter")
                        sFilter = attr.Value;
                }

                string filterName = filter.InnerText;

                filterList.Add(new Filter(filterName, filterType, sFilter));
            }
            currentFilters = filterList;

            return true;
        }

        //ivate Dictionary<string, string> 
    }

    //blic List<
}
