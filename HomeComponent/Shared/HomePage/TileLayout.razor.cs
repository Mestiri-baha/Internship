using HomeComponent.Model;
using HomeComponent.Services;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System.Numerics;
using Telerik.Blazor.Components;
using Telerik.Blazor.Components.Editor;
using Telerik.FontIcons;
using static Telerik.Blazor.IconType;
using static Telerik.Blazor.ThemeConstants.Button;

namespace HomeComponent.Shared.HomePage
{ 
    public partial class TileLayout
    {
    
    [Inject]
        public HomeUIService _Service { get; set; }
        
        HomeUIConfiguration data = new HomeUIConfiguration
        {
            Params = new List<Dictionary<string, object>>()
        };
        protected override async Task OnInitializedAsync()
        {

            data = await _Service.GetActionsAsync();

        }
        

        [Parameter] public RenderFragment svgIcon { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] 
        public string Tile_layout_title { get; set; }
        [Parameter] public int numberofColumns { get; set; }
        [Parameter] public string colorName { get; set; }
        [Parameter] public RenderFragment content { get; set; }

        protected RenderFragment CreateHeaderContent() => builder =>
        {
            builder.OpenComponent<TelerikTileLayout>(0);
            builder.AddAttribute(1, nameof(TelerikTileLayout.Columns), 5);
            builder.AddAttribute(2, nameof(TelerikTileLayout.Class), "task-list");
            builder.AddAttribute(3, nameof(TelerikTileLayout.ColumnWidth), "20rem");
            builder.AddAttribute(4, nameof(TelerikTileLayout.RowHeight), "14rem");
            builder.AddAttribute(5, nameof(TelerikTileLayout.Resizable), true);
            builder.AddAttribute(6, nameof(TelerikTileLayout.Reorderable), true);
            builder.AddAttribute(7, nameof(TelerikTileLayout.RowSpacing), "1px");

            builder.AddAttribute(8, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                for (int i = 0; i < data.Params.Count; i++)
                {
                    var item = data.Params[i];
                    Color colour = Color.FromName($"{item["color"]}");
                    Console.WriteLine(colour.ChangeColorBrightness(0.5f)); 
                    itemsBuilder.OpenComponent<TileLayoutItem>(9);
                    itemsBuilder.AddAttribute(10, nameof(TileLayoutItem.RowSpan), 1);
                    itemsBuilder.AddAttribute(11, "HeaderTemplate", (RenderFragment)((headerBuilder) =>
                    {
                        headerBuilder.OpenElement(12, "div");
                        headerBuilder.AddAttribute(13, "style","Background-color:"+"#"+$"{colour.ChangeColorBrightness(0.4f)}");
                        headerBuilder.OpenComponent<TelerikSvgIcon>(14);
                        headerBuilder.AddAttribute(15, "Class", "iconcontainer");
                        headerBuilder.AddAttribute(16, "ChildContent", CreateSvgIcon()); 
                        headerBuilder.CloseComponent();
                        headerBuilder.CloseElement();
                    }));
                    itemsBuilder.AddAttribute(17, "Content", CreateDynamicContent(i,item)); 
                    itemsBuilder.CloseComponent();
                }
            }));
            builder.CloseComponent();
        };
        private RenderFragment CreateTitleContent() => builder =>
        {
            builder.OpenElement(0, "h1"); // Open the <h1> element
            builder.AddAttribute(1, "style", "font-size: medium; margin-bottom: 22px; margin-top: 10px; margin-right: 2rem; margin-left: 1rem;");
            builder.OpenComponent<TelerikFontIcon>(2);
            builder.AddAttribute(3, nameof(TelerikFontIcon.Icon), FontIcon.Search);
            builder.AddAttribute(4, nameof(TelerikFontIcon.Size), "md");
            builder.AddAttribute(4, nameof(TelerikFontIcon.Class), "custom-font-icon-class ");
            builder.AddAttribute(4, nameof(TelerikFontIcon.ThemeColor), ThemeColor.Primary);
            builder.CloseComponent();
            builder.AddContent(5, "Actions à réaliser"); // Add the title content
            builder.CloseElement(); // Close the <h1> element
        };
        private RenderFragment CreateSvgIcon() => builder =>
        {
            // Create the SVG code dynamically
            //builder.OpenElement(0, "svg");
            //builder.AddAttribute(1, "viewBox", "0 0 512 512");
            builder.OpenElement(0, "img");
            builder.AddAttribute(1, "src", "https://img.icons8.com/ios/50/get-cash--v1.png");
            builder.AddAttribute(3,"width","50") ;
            builder.AddAttribute(3, "height", "50");
            builder.AddAttribute(1, "alt", "get-cash--v1");
            builder.AddAttribute(2, "class", "my-svg-icon");
            //builder.OpenElement(3, "path");
            //builder.AddAttribute(4, "d", "M434.7 82.7 480 128 192 416 32 256l45.3-45.3L192 325.5 434.7 82.7z");
            //builder.CloseElement();
            builder.CloseElement();
        };
        private RenderFragment CreateDynamicContent(int i , Dictionary<string, object> entry) => builder =>
        {
            builder.AddContent(0, AddContent(i,entry));
            // Add a <br> element to separate the number and text content
            builder.OpenElement(1, "br");
            builder.CloseElement();
            builder.OpenElement(2, "href"); 
            builder.AddAttribute(3, "style", "font-size: 12px ; text-align: center; ");
            builder.AddContent(2, $"{entry["title"]}");
            builder.CloseElement();

            //builder.OpenElement(1, "br");
            //builder.CloseElement();

        };
        private RenderFragment AddContent(int i , Dictionary<string,object> entry) => builder =>
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(3, "style", "font-size: 26px ; text-align: center; font-weight: bold ; color: #80ba27  ");
            Console.WriteLine(entry["count"]);
            if ((entry["count"]).ToString()=="0")
            {
                builder.OpenElement(0, "img");
                builder.AddAttribute(1, "src", "\\Images\\check-green.jpg");
                builder.CloseElement();

            }
            else
            {
                builder.AddContent(0, entry["count"]);
            }
            builder.CloseElement(); 
        };

    }
}

