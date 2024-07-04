using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CarRentalServies.CustomTag
{
    [HtmlTargetElement("Kevin")]
    public class CustomeDivTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);
            output.TagName = "div";
            output.Content.SetHtmlContent("<p>Your custom content here</p>");

        }
    }
}
