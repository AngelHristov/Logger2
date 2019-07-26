namespace LoggerLibrary.Layouts
{
    using System;

    using Layouts.Contracts;
    
    public class XmlLayout : ILayout
    {
        public string Format => "<log>" + Environment.NewLine +
                                "   <date>{0}</date>" + Environment.NewLine +
                                "   <level>{1}</level>" + Environment.NewLine +
                                "   <message>{1}</message>" + Environment.NewLine +
                                "</log>";
    }
}
