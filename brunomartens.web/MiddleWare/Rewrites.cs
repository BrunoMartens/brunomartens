using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using System.Net;

namespace brunomartens.web.MiddleWare
{
    public class Rewrites
    {
        public static void DoNotRedirectFilesOrApi(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Path.StartsWithSegments(new PathString("/api")) ||
                request.Path.Value.EndsWith(".css") ||
                request.Path.Value.EndsWith(".js"))
            {
                context.Result = RuleResult.SkipRemainingRules;
            }
        }
    }
}
