<%@ Page Language="C#" %>
<%@ Import Namespace="System.Xml.XPath" %>
<%@ Import Namespace="System.Xml.Xsl" %>

<%
    XPathDocument document = new XPathDocument(Server.MapPath("OrdersInformation.xml"));
    XslCompiledTransform xsl = new XslCompiledTransform();
    xsl.Load(Server.MapPath("OrdersInformation.xsl"));
    xsl.Transform(document, null, Response.OutputStream);
%>