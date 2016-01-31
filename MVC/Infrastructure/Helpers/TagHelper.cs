using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Infrastructure.Helpers
{
    public static class TagHelper
    {
        public static MvcHtmlString ParseTags(this HtmlHelper html, string description)
        {
            
            string result = "";
            for (int i = 0; i < description.Length; ++i)
            {
                if (description[i] == '#')
                {
                    ++i;
                    string href = "/Search/Find/";
                    string text = "";
                    while (i < description.Length && description[i] != ' ' && description[i] != '#')
                    {
                        text += description[i++];
                    }
                    href += text;
                    TagBuilder a = new TagBuilder("a");
                    a.MergeAttribute("href", href);
                    a.SetInnerText("#" + text);
                    result += a.ToString();
                    --i;
                }
                else
                {
                    result += description[i];
                }
            }
            return new MvcHtmlString(result);
        }
    }
}