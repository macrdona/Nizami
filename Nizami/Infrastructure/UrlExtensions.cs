using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Nizami.Infrastructure
{

    public static class UrlExtensions
    {
        /*
         *  This method generates a URL that the browser will be returned to after the
         *  cart has been updated, taking into account the query string if there is one.
         */
        public static string PathAndQuery(this HttpRequest request) =>
        request.QueryString.HasValue
        ? $"{request.Path}{request.QueryString}"
        : request.Path.ToString();

        public static string AdminLogin(this HttpRequest request) => "/Admin/ProductList";
        public static string AdminLogin() => "/Admin/ProductList";

        public static string UserSignUp(this HttpRequest request) => "/Home/PostLogin";
        public static string UserSignUp() => "/Home/PostLogin";

        public static string UserLogin(this HttpRequest request) => "/Home/PostLogin";
        public static string UserLogin() => "/Home/PostLogin";

        public static string HomePage(this HttpRequest request) => "/Home/Index";

    }
}
