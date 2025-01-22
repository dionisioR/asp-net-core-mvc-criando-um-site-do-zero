using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LancheMac_SSMS.TagHelpers {
    public class EmailTagHelper : TagHelper {

        // endereco de email
        public string Endereco { get; set; }
        // conteudo do email
        public string Conteudo { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            output.TagName = "a";  // link / tag <a>
            output.Attributes.SetAttribute("href", "mailto:" + Endereco);
            output.Content.SetContent(Conteudo);
        }
    }
}
