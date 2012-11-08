using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Swagger.Net.Utilities
{
    public class XmlCommentDocumentationReader
    {
        XPathNavigator _documentNavigator;
        private const string _methodExpression = "/doc/members/member[@name='M:{0}']";
        private static Regex nullableTypeNameRegex = new Regex(@"(.*\.Nullable)" + Regex.Escape("`1[[") + "([^,]*),.*");

        public XmlCommentDocumentationReader(string documentPath)
        {
            XPathDocument xpath = new XPathDocument(documentPath);
            _documentNavigator = xpath.CreateNavigator();
        }

        public virtual string GetSummary(MethodInfo method)
        {
            XPathNavigator memberNode = GetMemberNode(method);
            if (memberNode != null)
            {
                XPathNavigator summaryNode = memberNode.SelectSingleNode("summary");
                if (summaryNode != null)
                {
                    return ToHtml(summaryNode).Trim();
                }
            }

            return null;
        }

        public virtual string GetRemarks(MethodInfo method)
        {
            XPathNavigator memberNode = GetMemberNode(method);
            if (memberNode != null)
            {
                XPathNavigator summaryNode = memberNode.SelectSingleNode("remarks");
                if (summaryNode != null)
                {
                    return ToHtml(summaryNode).Trim();
                }
            }

            return null;
        }

        public virtual string GetReturns(MethodInfo method)
        {
            XPathNavigator memberNode = GetMemberNode(method);
            if (memberNode != null)
            {
                XPathNavigator summaryNode = memberNode.SelectSingleNode("returns");
                if (summaryNode != null)
                {
                    return ToHtml(summaryNode).Trim();
                }
            }

            return null;
        }
        public virtual IDictionary<string, string> GetParameters(MethodInfo method)
        {
            XPathNavigator memberNode = GetMemberNode(method);
            if (memberNode != null)
            {
                return (from XPathNavigator node in memberNode.SelectChildren("param", string.Empty)
                        select node).ToDictionary(
                            key => key.GetAttribute("name", string.Empty),
                            val => val.Value);
                //new KeyValuePair<string, string>(node.GetAttribute("name",string.Empty), node.Value);

            }

            return null;
        }


        public virtual string GetParameterDocs(MethodInfo method, string parameterName)
        {
            XPathNavigator memberNode = GetMemberNode(method);
            if (memberNode != null)
            {
                XPathNavigator parameterNode = memberNode.SelectSingleNode(string.Format("param[@name='{0}']", parameterName));
                if (parameterNode != null)
                {
                    return ToHtml(parameterNode).Trim();
                }
            }

            return null;
        }



        private XPathNavigator GetMemberNode(MethodInfo method)
        {
            string selectExpression = string.Format(_methodExpression, GetMemberName(method));
            XPathNavigator node = _documentNavigator.SelectSingleNode(selectExpression);
            if (node != null)
            {
                return node;
            }

            return null;
        }

        private static string GetMemberName(MethodInfo method)
        {
            string name = string.Format("{0}.{1}", method.DeclaringType.FullName, method.Name);
            var parameters = method.GetParameters();
            if (parameters.Length != 0)
            {
                string[] parameterTypeNames = parameters.Select(param => getTypeName(param.ParameterType)).ToArray();
                name += string.Format("({0})", string.Join(",", parameterTypeNames));
            }

            return name;
        }

        private static string getTypeName(Type type)
        {
            //handle nullable
            var result = nullableTypeNameRegex.Match(type.FullName);
            if (result.Success)
            {
                return string.Format("{0}{{{1}}}", result.Groups[1].Value, result.Groups[2].Value);
            }

            // handle array types
            //var innerType = type.FindEnumerableType();
            //if (innerType != null) return getTypeName(innerType);

            //return type.FriendlyName();
            return type.Name;
        }

        /// <summary>
        /// Converts XML docs to HTML version
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private string ToHtml(XPathNavigator element)
        {
            // some very ghetto conversions here, this can be much better but i'm going for fast PoC here..
            return Regex.Replace(
                element.InnerXml.Replace("<code>", "<pre>").Replace("</code>", "</pre>"),
                "\\r\\n\\s*\\r\\n", "<br/>\r\n<br/>\r\n" // replace two newlines with two <br>'s
            ); 
        }


    }
       
}
