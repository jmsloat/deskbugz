﻿using System;
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
        string _errorDescription;
        string _errorCode = "-1";

        public string ErrorDescription
        {
            get { return _errorDescription;}
            set { _errorDescription = value;} 
        }

        public string ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        Dictionary<string, string> responseParams;
    }

    public enum ApiActions
    {
        LOGON,
        LIST_FILTERS
    }

    public class LogonResponseHandler : IXMLResponseHandler
    {
        public XmlResponsePacket handle(XmlDocument doc)
        {
            string token; //api token supplied by the FogBugz api

            XmlResponsePacket packet = new XmlResponsePacket();

            //API will return a token if successful,  an error code if unsuccessful.
            XmlNodeList errNode = doc.GetElementsByTagName("error");
            System.Console.WriteLine(doc.ToString());
            if (errNode.Count > 0)
            {
                //FIXME: Different error codes will require different handling ( multiple users, incorrect password, etc. )
                //Should look for these at some point in the future. 
                //errorCode = errNode[0].Name;
                packet.ErrorCode = errNode[0].Name;
                packet.ErrorDescription = errNode[0].Value;

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
            Properties.Settings.Default.Save();

            return packet;
        }
    }
}
