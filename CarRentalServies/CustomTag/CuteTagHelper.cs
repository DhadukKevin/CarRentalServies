using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Security.Cryptography.X509Certificates;

namespace CarRentalServies.CustomTag
{
    [HtmlTargetElement("Cute")]
    public class CuteTagHelper : TagHelper
    {
        public string ImageLink { get; set; }
        public string AltText { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "img";
            output.TagMode = TagMode.StartTagOnly;
            output.Attributes.SetAttribute("src",ImageLink);
            output.Attributes.SetAttribute("alt", AltText);

        }
    }
}
