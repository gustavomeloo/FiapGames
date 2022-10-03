using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Razor.TagHelpers;


namespace Fiap.Aula02.Web.Exemplo01.TagHelpers
{
    public class BotaoTagHelper : TagHelper
    {

        //atributos das tags
        public string Texto { get; set; }
        public string Class { get; set; }

        //<botao></botao>
        //<input type="submit" value "cadastrar" class="btn btn-success" />

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Define o nome da tag
            output.TagName = "input";
            //Define o type da tag
            output.Attributes.SetAttribute("type", "submit");

            //define o valor da tag
            if (string.IsNullOrEmpty(Texto))
                output.Attributes.SetAttribute("value", "submit");
            else
                output.Attributes.SetAttribute("value", Texto);

            //define o class da tag
            
            output.Attributes.SetAttribute("class", string.IsNullOrEmpty(Class)?"btn btn-outline-primary":Class);
        }

    }
}
