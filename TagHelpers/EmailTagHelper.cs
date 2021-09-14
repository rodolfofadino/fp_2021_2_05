using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fiapweb.TagHelpers
{
    public class EmailTagHelper :TagHelper
    {
        public string MailTo { get; set; }
        public string PropriedadePublica { get; set; }

        const string Domain = "fiap.com.br";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; //div li ul qualquer html

            var address = $"{MailTo}@{Domain}";

            output.Attributes.SetAttribute("href", $"mailto:{address}");
            output.Content.SetContent(address);
        }
    }
}
