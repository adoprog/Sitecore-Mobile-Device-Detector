<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="FiftyOne_Mobile_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to the Mobile Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome to the Mobile Home Page</h1>
        <% 
            try
            {
                var version = System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
                if (version.StartsWith("v2"))
                { %>
            <p style="color: Red;"><b>
            IMPORTANT: The NuGet version of 51Degrees.mobi requires .NET v4 or greater to run automatically.
            Please change your project to run under .NET v4 then uninstall and reinstall the 51Degrees.mobi NuGet package. 
            See the <a href="http://51degrees.com/Support/Documentation/NET">User Guide</a> for more information.
            </b></p>    
        <%  } }
            catch { }
        %>
        <hr />
        <% if (Request.Browser.IsMobileDevice == false) { %>
            <p>The requesting device isn't a mobile. The page must have been requested directly.</p>
            <p>Try accessing the web site from a mobile device, or a mobile device emulator. A list of popular mobile emulators can be found <a href="http://51degrees.com/Support/FAQs/MobileEmulators.aspx" title="Mobile Emulators">here</a>.</p>
        <% } %>
        <hr />
        <p>Here's some information about the requesting device:</p>
        <ul>
            <li><h2>Popular Properties</h2></li>
            <li><% =GetPropertyLinkHTML("IsMobile")%>: <% =Request.Browser.IsMobileDevice %></li>
            <li><% =GetPropertyLinkHTML("ScreenPixelsWidth")%>: <% =Request.Browser.ScreenPixelsWidth %></li>
            <li><% =GetPropertyLinkHTML("ScreenPixelsHeight")%>: <% =Request.Browser.ScreenPixelsHeight %></li>
            <li><% =GetPropertyLinkHTML("ScreenMMWidth")%>: <% =GetPropertyHTML("ScreenMMWidth") %></li>
            <li><% =GetPropertyLinkHTML("ScreenMMHeight")%>: <% =GetPropertyHTML("ScreenMMHeight") %></li>
            <li><% =GetPropertyLinkHTML("ScreenInchesSquare")%>: <% =GetPropertyHTML("ScreenInchesSquare") %></li>
            <li><% =GetPropertyLinkHTML("IsTablet")%>: <% =GetPropertyHTML("IsTablet") %></li>
            <li><% =GetPropertyLinkHTML("IsSmartPhone")%>: <% =GetPropertyHTML("IsSmartPhone") %></li>
            <li><h2>Browser Properties</h2></li>
            <li><% =GetPropertyLinkHTML("LayoutEngine")%>: <% =GetPropertyHTML("LayoutEngine") %></li>
            <li><% =GetPropertyLinkHTML("AnimationTiming")%>: <% =GetPropertyHTML("AnimationTiming") %></li>
            <li><% =GetPropertyLinkHTML("BlobBuilder")%>: <% =GetPropertyHTML("BlobBuilder") %></li>
            <li><% =GetPropertyLinkHTML("CssBackground")%>: <% =GetPropertyHTML("CssBackground") %></li>
            <li><% =GetPropertyLinkHTML("CssBorderImage")%>: <% =GetPropertyHTML("CssBorderImage") %></li>
            <li><% =GetPropertyLinkHTML("CssCanvas")%>: <% =GetPropertyHTML("CssCanvas") %></li>
            <li><% =GetPropertyLinkHTML("CssColor")%>: <% =GetPropertyHTML("CssColor") %></li>
            <li><% =GetPropertyLinkHTML("CssColumn")%>: <% =GetPropertyHTML("CssColumn") %></li>
            <li><% =GetPropertyLinkHTML("CssFlexbox")%>: <% =GetPropertyHTML("CssFlexbox") %></li>
            <li><% =GetPropertyLinkHTML("CssFont")%>: <% =GetPropertyHTML("CssFont") %></li>
            <li><% =GetPropertyLinkHTML("CssMediaQueries")%>: <% =GetPropertyHTML("CssMediaQueries") %></li>
            <li><% =GetPropertyLinkHTML("CssMinMax")%>: <% =GetPropertyHTML("CssMinMax") %></li>
            <li><% =GetPropertyLinkHTML("CssOverflow")%>: <% =GetPropertyHTML("CssOverflow") %></li>
            <li><% =GetPropertyLinkHTML("CssPosition")%>: <% =GetPropertyHTML("CssPosition") %></li>
            <li><% =GetPropertyLinkHTML("CssText")%>: <% =GetPropertyHTML("CssText") %></li>
            <li><% =GetPropertyLinkHTML("CssTransforms")%>: <% =GetPropertyHTML("CssTransforms") %></li>
            <li><% =GetPropertyLinkHTML("CssTransitions")%>: <% =GetPropertyHTML("CssTransitions") %></li>
            <li><% =GetPropertyLinkHTML("CssUI")%>: <% =GetPropertyHTML("CssUI") %></li>
            <li><% =GetPropertyLinkHTML("DataSet")%>: <% =GetPropertyHTML("DataSet") %></li>
            <li><% =GetPropertyLinkHTML("DataUrl")%>: <% =GetPropertyHTML("DataUrl") %></li>
            <li><% =GetPropertyLinkHTML("DeviceOrientation")%>: <% =GetPropertyHTML("DeviceOrientation") %></li>
            <li><% =GetPropertyLinkHTML("FileReader")%>: <% =GetPropertyHTML("FileReader") %></li>
            <li><% =GetPropertyLinkHTML("FileSaver")%>: <% =GetPropertyHTML("FileSaver") %></li>
            <li><% =GetPropertyLinkHTML("FileWriter")%>: <% =GetPropertyHTML("FileWriter") %></li>
            <li><% =GetPropertyLinkHTML("FormData")%>: <% =GetPropertyHTML("FormData") %></li>
            <li><% =GetPropertyLinkHTML("Fullscreen")%>: <% =GetPropertyHTML("Fullscreen") %></li>
            <li><% =GetPropertyLinkHTML("GeoLocation")%>: <% =GetPropertyHTML("GeoLocation") %></li>
            <li><% =GetPropertyLinkHTML("History")%>: <% =GetPropertyHTML("History") %></li>
            <li><% =GetPropertyLinkHTML("Html-Media-Capture")%>: <% =GetPropertyHTML("Html-Media-Capture") %></li>
            <li><% =GetPropertyLinkHTML("Iframe")%>: <% =GetPropertyHTML("Iframe") %></li>
            <li><% =GetPropertyLinkHTML("IndexedDB")%>: <% =GetPropertyHTML("IndexedDB") %></li>
            <li><% =GetPropertyLinkHTML("Json")%>: <% =GetPropertyHTML("Json") %></li>
            <li><% =GetPropertyLinkHTML("Masking")%>: <% =GetPropertyHTML("Masking") %></li>
            <li><% =GetPropertyLinkHTML("PostMessage")%>: <% =GetPropertyHTML("PostMessage") %></li>
            <li><% =GetPropertyLinkHTML("Progress")%>: <% =GetPropertyHTML("Progress") %></li>
            <li><% =GetPropertyLinkHTML("Prompts")%>: <% =GetPropertyHTML("Prompts") %></li>
            <li><% =GetPropertyLinkHTML("Selector")%>: <% =GetPropertyHTML("Selector") %></li>
            <li><% =GetPropertyLinkHTML("Svg")%>: <% =GetPropertyHTML("Svg") %></li>
            <li><% =GetPropertyLinkHTML("TouchEvents")%>: <% =GetPropertyHTML("TouchEvents") %></li>
            <li><% =GetPropertyLinkHTML("Track")%>: <% =GetPropertyHTML("Track") %></li>
            <li><% =GetPropertyLinkHTML("Video")%>: <% =GetPropertyHTML("Video") %></li>
            <li><% =GetPropertyLinkHTML("Viewport")%>: <% =GetPropertyHTML("Viewport") %></li>
        </ul>
        <hr />
        <h2>Device Data Information</h2>
        <p>Data Published: <% =FiftyOne.Foundation.Mobile.Detection.WebProvider.ActiveProvider.DataSet.Published %></p>
        <p>Version Name: <% =FiftyOne.Foundation.Mobile.Detection.WebProvider.ActiveProvider.DataSet.Name %></p>
        <p>Version Format: <% =FiftyOne.Foundation.Mobile.Detection.WebProvider.ActiveProvider.DataSet.Format %></p>
        <hr />
        <p>See <a href="http://msdn.microsoft.com/en-us/library/system.web.httpbrowsercapabilities_properties.aspx" title="MSDN HttpBrowserCapabilities Documentation">MSDN</a> for details of Request.Browser properties.</p>
        <p>See <a href="http://51degrees.com/Support/Documentation/NET" title="51Degrees Documentation">51Degrees</a> for user guide.</p>
		<p>See <a href="http://51degrees.com/Products/Device-Detection" title="51Degrees Device Data">51Degrees Device Data Updates</a> for ways to automatically update device data and extend properties.</p>
        <p>See <a href="http://51degrees.com/Resources/Property-Dictionary" title="51Degrees Available Properties">51Degrees Device Properties</a> for a full list of properties.</p>
    </div>
    </form>
</body>
</html>