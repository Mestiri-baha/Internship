using HomeComponent.Model;
using HomeComponent.Services;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using System.Numerics;
using System.Reflection.Metadata;
using Telerik.Blazor.Components;
using Telerik.Blazor.Components.Editor;
using Telerik.FontIcons;
using static System.Net.WebRequestMethods;
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
        public void ActionsEventHandler(string action)
        {
            _Service.DoAction(action);
        }
        List<String> IconsLinks = new List<string>()
        {
            "https://img.icons8.com/ios/50/bill.png",
            "https://img.icons8.com/ios/50/get-cash--v1.png",
            "https://img.icons8.com/ios/50/receipt.png",
            "https://img.icons8.com/ios/50/apartment.png",
            "https://img.icons8.com/ios/50/get-cash--v1.png",
            "https://img.icons8.com/ios/50/apartment.png"


        };
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
            builder.AddAttribute(3, nameof(TelerikTileLayout.ColumnWidth), "177px"); //20rm
            builder.AddAttribute(4, nameof(TelerikTileLayout.RowHeight), "14rem");
            builder.AddAttribute(5, nameof(TelerikTileLayout.Resizable), false);
            builder.AddAttribute(6, nameof(TelerikTileLayout.Reorderable), true);
            builder.AddAttribute(7, nameof(TelerikTileLayout.RowSpacing), "1px");

            builder.AddAttribute(8, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                int x = 0;
                for (int i = 0; i < data.Params.Count; i++)
                {
                    var item = data.Params[i];
                    int length = data.Params.Count; 
                    Color colour = Color.FromName($"{item["color"]}");
                    Console.WriteLine(colour.ChangeColorBrightness(0.5f)); 
                    itemsBuilder.OpenComponent<TileLayoutItem>(9);
                    itemsBuilder.AddAttribute(10, nameof(TileLayoutItem.RowSpan), 1);
                    itemsBuilder.AddAttribute(11, "Class","k - tilelayout - item");
                    itemsBuilder.AddAttribute(11, "HeaderTemplate", (RenderFragment)((headerBuilder) =>
                    {
                       
                        headerBuilder.OpenElement(12, "div");
                        headerBuilder.AddAttribute(13, "style","Background-color:"+"#"+$"{colour.ChangeColorBrightness(0.5f)} ; ");
                        headerBuilder.OpenComponent<TelerikSvgIcon>(14);
                        headerBuilder.AddAttribute(15, "Class", "iconcontainer");
                        headerBuilder.AddAttribute(16, "ChildContent", CreateSvgIcon(x)); 
                        Console.WriteLine("baha "+ x);
                        headerBuilder.CloseComponent();
                        headerBuilder.CloseElement();
                        x++; 
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
            builder.AddContent(5,"Actions à réaliser"); // Add the title content
            builder.CloseElement(); // Close the <h1> element
        };
        private RenderFragment CreateSvgIcon(int i) => builder =>
        {
            // Create the SVG code dynamically
            //builder.OpenElement(0, "svg");
            //builder.AddAttribute(1, "viewBox", "0 0 512 512");
            
            
            
                builder.OpenElement(0, "img"); 
                builder.AddAttribute(1, "src", $"{IconsLinks.ElementAt(i)}");
                builder.AddAttribute(2, "onclick", "");
                builder.AddAttribute(3, "style", "cursor: pointer;");
                builder.AddAttribute(3, "width", "50");
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
            builder.OpenElement(2, "a");
            builder.AddAttribute(3, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this,
                                               () => ActionsEventHandler(entry["Action"].ToString())));
            builder.AddAttribute(3, "style", "font-size: 12px ; text-align: center; cursor: pointer; display: inherit ;  ");
            builder.AddContent(4, $"{entry["title"]}");
            builder.OpenElement(5, "br");
            builder.CloseElement();
            builder.OpenElement(6, "small");
            builder.AddAttribute(3, "style", "color: gray ; ");

            builder.AddContent(7, $"{entry["subtitle"]}");
            builder.CloseElement();

            builder.CloseElement();

            //builder.OpenElement(1, "br");
            //builder.CloseElement();

        };
        private RenderFragment AddContent(int i , Dictionary<string,object> entry) => builder =>
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(2, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this,
                                               () => ActionsEventHandler(entry["Action"].ToString())));
            
            builder.AddAttribute(3, "style", "font-size: 26px ; text-align: center; font-weight: bold ; color: #80ba27 ; cursor: pointer; ");
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

