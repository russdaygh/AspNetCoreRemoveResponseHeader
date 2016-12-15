using System;
using System.Collections.Generic;

namespace RemoveResponseHeaders
{
    public class RemoveResponseHeadersOptions
    {
        public IEnumerable<string> HeaderNames { get; }

        public RemoveResponseHeadersOptions(IEnumerable<string> headerNames)
        {
            if (headerNames == null) throw new ArgumentNullException(nameof(headerNames));

            HeaderNames = headerNames;
        }
    }
}
