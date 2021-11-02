﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class ArticleBusiness
    {
        public static List<string> getLinks(string url, string xpath, string toPath = "")
        {

            List<string> links = new List<string>();
            HtmlNode[] nodes = getNodesByXPath(url, xpath);
            for (int i = 0; i < 5; i++)
            {
                links.Add(toPath + nodes[i].FirstChild.Attributes["href"].Value.ToString());
            }
            return links;
        }
        public static HtmlNode[] getNodesByXPath(string url, string xpath)
        {
            HtmlWeb web = new HtmlWeb();
            List<string> links = new List<string>();
            HtmlDocument doc = web.Load(url);
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes(xpath).TakeWhile(item => !item.InnerHtml.Contains("https://www.wired.com/newsletter?sourceCode=BottomStories")).ToArray();


            return nodes;
        }

    }
}
