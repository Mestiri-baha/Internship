using HomeComponent.Model;
using HomeComponent.Services;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using static Telerik.Blazor.ThemeConstants.Button;

namespace HomeComponent.Shared.HomePage
{
    public partial class CardsTileLayout
    {
        HomeUIConfiguration data = new HomeUIConfiguration
        {
            Params = new List<Dictionary<string, object>>()
        };
        [Inject]
        private  HomeUIService _Service { get; set; }
        protected override async Task OnInitializedAsync()
        {
            data = await _Service.GetControlsAsync(); 
        }
        public void ActionsEventHandler(string url)
        {
            _Service.DoAction(url);
        }
        private RenderFragment CreateTileLayoutContent() => builder =>
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "CardsTile");
            // Render the title
            builder.OpenElement(2, "h1");
            builder.AddAttribute(3, "style", "font-size: medium; margin-top: 20px; margin-left: 1rem;  margin-bottom: 22px;");
            builder.OpenComponent<TelerikFontIcon>(4);
            builder.AddAttribute(5, nameof(TelerikFontIcon.Icon), FontIcon.Eye);
            builder.AddAttribute(6, nameof(TelerikFontIcon.Size), "md");
            builder.AddAttribute(7, nameof(TelerikFontIcon.Class), "custom-font-icon-class ");
            builder.AddAttribute(8, nameof(TelerikFontIcon.ThemeColor), ThemeColor.Primary);
            builder.CloseComponent();
            builder.AddContent(10, "Contrôle à réaliser");
            builder.CloseElement();
            // Render the TelerikTileLayout
            builder.OpenComponent<TelerikTileLayout>(11);
            builder.AddAttribute(12, "Columns", data.Params.Count);
            builder.AddAttribute(13, "Class", "task-list1");
            builder.AddAttribute(14, "ColumnWidth", "3fr");
            builder.AddAttribute(15, "RowHeight", "3fr");
            builder.AddAttribute(16, "Resizable", false);
            builder.AddAttribute(17, "RowSpacing", "0px");
            builder.AddAttribute(18, "Reorderable", true);
            builder.AddAttribute(19, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                // Render multiple TileLayoutItems based on the data from the JSON file
                for (int i = 0; i < data.Params.Count; i++)
                {
                    var item = data.Params[i];  
                    // Render a single TileLayoutItem
                    itemsBuilder.OpenComponent<TileLayoutItem>(20);
                    itemsBuilder.AddAttribute(21, "Class", "Child");
                    // Render the content (number + text) for each TileLayoutItem
                    itemsBuilder.AddAttribute(22, "Content", (RenderFragment)((contentBuilder) =>
                    {
                        contentBuilder.OpenElement(23, "a");
                        contentBuilder.AddAttribute(24, "style", "text-decoration: inherit; color: inherit;");
                        contentBuilder.AddAttribute(25, "href",$"http://localhost:50742/HomePage/action={item["Action"]}"); 
                        contentBuilder.AddAttribute(26,"onclick",Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this,() => ActionsEventHandler(item["Action"].ToString())));
                        contentBuilder.OpenElement(27, "div");
                        contentBuilder.OpenElement(28, "br");
                        contentBuilder.CloseElement();
                        // Apply the orange color to the number
                        contentBuilder.OpenElement(29, "span");
                        contentBuilder.AddAttribute(30, "style", "color: orange; font-weight: bold ; font-size : 24px ;");
                        contentBuilder.AddContent(31, item["count"]); // Replace "number" with the actual number value
                        contentBuilder.CloseElement();
                        contentBuilder.OpenElement(32, "br");
                        contentBuilder.CloseElement();
                        contentBuilder.OpenElement(33, "br");
                        contentBuilder.CloseElement();
                        // Add the text content
                        contentBuilder.OpenElement(34, "span");
                        contentBuilder.AddAttribute(35, "style", "color: black ; font-size : 10.5px ;");
                        contentBuilder.AddContent(36, item["label"]);
                        contentBuilder.CloseElement();
                        contentBuilder.OpenElement(37, "br");
                        contentBuilder.CloseElement();
                        contentBuilder.CloseElement();
                        contentBuilder.CloseElement();
                    }));
                    itemsBuilder.CloseComponent();
                }
            }));
            builder.CloseComponent();
            builder.CloseElement();
        };

    }

}

