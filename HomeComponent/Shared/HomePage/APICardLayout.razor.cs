using HomeComponent.Model;
using HomeComponent.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using System.Net;
using System.Text.Json;
using System.Xml.Linq;
using Telerik.Blazor.Components;
using Telerik.SvgIcons;

namespace HomeComponent.Shared.HomePage
{
    public partial class APICardLayout
    {
        [Inject]
        public HomeUIService _Service { get; set; }
       
        HomeUIConfiguration data = new HomeUIConfiguration
        {
            Params = new List<Dictionary<string, object>>()
        };
        protected override async Task OnInitializedAsync()
        {
            data = await _Service.GetNewsAsync(); 
        }
       
        public string ImageUrl  = "\\Images\\img-actu.jpg";
        
        private RenderFragment CreateApiCard() => builder =>
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "ApiCard");
            builder.OpenComponent<TelerikTileLayout>(2);
            builder.AddAttribute(3, "Columns", 1);
            builder.AddAttribute(4, "Class", "apicard-style");
            builder.AddAttribute(5, "RowHeight", "800px");
            builder.AddAttribute(6, "ColumnWidth", "20rem");
            builder.AddAttribute(7, "Resizable", false);
            builder.AddAttribute(8, "Reorderable", false);
            builder.AddAttribute(10, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                itemsBuilder.OpenComponent<TileLayoutItem>(11);
                itemsBuilder.AddAttribute(12, nameof(TileLayoutItem.RowSpan), 1);
                itemsBuilder.AddAttribute(13, "HeaderTemplate", (RenderFragment)((headerBuilder) =>
                {
                    headerBuilder.OpenElement(14, "img");
                    headerBuilder.AddAttribute(15, "width", "340px");
                    headerBuilder.AddAttribute(15, "height", "162px");
                    headerBuilder.AddAttribute(16, "src", ImageUrl);
                    headerBuilder.AddAttribute(17, "alt", "Image");
                    headerBuilder.CloseElement();
                }));
                
              
                itemsBuilder.AddAttribute(18, "Content", RenderDynamicContent());



                //itemsBuilder.AddAttribute(18, "Content", RenderDynamicContent()); 
                itemsBuilder.CloseComponent();

            }));
            builder.CloseComponent(); // Close the TelerikTileLayout component
            builder.CloseElement(); // Close the <div class='ApiCard'> element
        };
        public RenderFragment RenderDynamicContent() => builder =>
       {
         
          ;
           int i = 0;
           foreach (var item in data.Params)
           {
               i++;
               if (i != (data.Params.Count / 2))
                   {
                   builder.OpenElement(0, "div");
                   builder.OpenElement(1, "h3");
                   builder.AddAttribute(1, "style", "font-size: 12px; font-weight : bold ; margin : 0px ;");
                   builder.AddContent(3, item["title"]);
                   builder.CloseElement();
                   builder.OpenElement(4, "h4");
                   builder.AddAttribute(5, "style", "font-size: 12px; margin : 0px ;");
                   builder.AddContent(6, "ACTUALITÉS " + item["title"] + "...");
                   builder.CloseElement();
                   builder.OpenElement(7, "h6");
                   builder.OpenElement(8, "a");
                   builder.AddAttribute(9, "href", $"{item["link"]}");
                   builder.AddAttribute(10, "target", "_blank");
                   builder.AddAttribute(11, "style", "font-size: 12px;margin : 0px ;");

                   builder.AddContent(12, "Lire la suite ");
                   builder.CloseElement();
                   builder.CloseElement();
                   builder.OpenElement(13, "hr");
                   builder.CloseElement();
                   builder.CloseElement();
               }
           }

           
           builder.OpenElement(13, "a");
           builder.AddAttribute(14, "href", "https://www.salviadeveloppement.fr/hotfix-2-de-salvia-patrimoine-v23-0/");
           builder.AddAttribute(14, "target", "_blank");

           builder.OpenElement(10, "Button");
           builder.AddAttribute(11, "Class", "btn");
           builder.AddContent(12, "Toutes Les Actualitées");
           builder.CloseElement();
           builder.CloseElement();

       };
           

       };


        
    
}
