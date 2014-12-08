﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Windows.Forms;

namespace deskbugz
{
    public class FBNet
    {
        public bool buildRequest(string url, Dictionary<string, string> args, FBXml.XMLResponse ResponseHandler)
        {
            StringBuilder urlBuilder = new StringBuilder(url);
            foreach(string key in args.Keys)
            {
                urlBuilder.Append(String.Format("{0}={1}&", key, args[key]));
                System.Console.WriteLine(key);
            }

            HttpWebRequest req = null;
            try
            {
                req = (HttpWebRequest)WebRequest.Create(urlBuilder.ToString());
            }
            catch(UriFormatException)
            {
                //URL isn't valid. Notify The user. 
                MessageBox.Show(String.Format("URL {0} is invalid",url), "URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            WebResponse resp = null;
            try
            {
                resp = req.GetResponse();
                using (var reader = XmlReader.Create(new StreamReader(resp.GetResponseStream())))
                {  
                    XmlDocument doc = new XmlDocument();
                    doc.Load(reader);
                    return ResponseHandler(doc);
                }
            }
            catch(IOException e)
            {
                System.Console.WriteLine(e.ToString());
                return false;
            }

        }

    }

    public struct Filter
    {
        public Filter(string name, string type, string sfilter)
        {
            this.Name = name;
            this.Type = type;
            this.sFilter = sfilter;
        }

        string Name;
        string Type;
        string sFilter;
    }

    
}
