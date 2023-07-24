// Define the properties that you want to make generic
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using static Telerik.Blazor.IconType;
using static Telerik.Blazor.ThemeConstants.Button;

namespace HomeComponent.Shared.HomePage
{
    public partial class TileLayout
    {
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
            builder.AddAttribute(3, nameof(TelerikTileLayout.ColumnWidth), "14rem");
            builder.AddAttribute(4, nameof(TelerikTileLayout.RowHeight), "10rem");
            builder.AddAttribute(5, nameof(TelerikTileLayout.Resizable), true);
            builder.AddAttribute(6, nameof(TelerikTileLayout.Reorderable), true);
            builder.AddAttribute(7, nameof(TelerikTileLayout.RowSpacing), "1px");

            builder.AddAttribute(8, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                for (int i = 0; i < 5; i++)
                {
                    itemsBuilder.OpenComponent<TileLayoutItem>(9);
                    itemsBuilder.AddAttribute(10, nameof(TileLayoutItem.RowSpan), 1);
                    itemsBuilder.AddAttribute(11, "HeaderTemplate", (RenderFragment)((headerBuilder) =>
                    {
                        headerBuilder.OpenElement(12, "div");
                        headerBuilder.AddAttribute(13, "style", "background-color: gold");
                        headerBuilder.OpenComponent<TelerikSvgIcon>(14);
                        headerBuilder.AddAttribute(15, "Class", "iconcontainer");
                        headerBuilder.AddAttribute(16, "ChildContent", CreateSvgIcon()); 
                        headerBuilder.CloseComponent();
                        headerBuilder.CloseElement();
                    }));
                    itemsBuilder.AddAttribute(17, "Content", CreateDynamicContent()); 
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
            builder.AddContent(5, "Baha Mestiri"); // Add the title content
            builder.CloseElement(); // Close the <h1> element
        };
        private RenderFragment CreateSvgIcon() => builder =>
        {
            // Create the SVG code dynamically
            builder.OpenElement(0, "svg");
            builder.AddAttribute(1, "viewBox", "0 0 512 512");
            builder.AddAttribute(2, "class", "my-svg-icon");
            builder.OpenElement(3, "path");
            builder.AddAttribute(4, "d", "M434.7 82.7 480 128 192 416 32 256l45.3-45.3L192 325.5 434.7 82.7z");
            builder.CloseElement();
            builder.CloseElement();
        };
        private RenderFragment CreateDynamicContent() => builder =>
        {
            builder.AddContent(0, "123");

            // Add a <br> element to separate the number and text content
            builder.OpenElement(1, "br");
            builder.CloseElement();

            // Add the text content ("This is the text.") inside the contentBuilder
            builder.AddContent(2, "This is the text.");

        };

    }
}

