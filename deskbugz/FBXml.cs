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
            token = Properties.Settings.Default.token;
            fbUrl = Properties.Settings.Default.site;
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

            //store the fogbugz url into application settings (to prevent requiring constant logins)
            Properties.Settings.Default.site = fbUrl;
            Properties.Settings.Default.Save();
            IXMLResponseHandler handler = XmlResponseHandlerFactory.Create(ApiActions.LOGON);

            bool success = false;
            XmlResponsePacket response = net.buildRequest(realurl, args, handler);
            if (response.ErrorCode == "-1")
                success = true;

            return success;
        }

        public List<Filter> getFilters()
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args["cmd"] = "listFilters";
            args["token"] = token;

            //bool success = this.net.buildRequest(fbUrl, args, new XMLResponse(ListFiltersResponseHandler));

            return this.currentFilters;
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
