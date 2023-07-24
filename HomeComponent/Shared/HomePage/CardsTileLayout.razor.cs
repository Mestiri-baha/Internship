using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using static Telerik.Blazor.ThemeConstants.Button;

namespace HomeComponent.Shared.HomePage
{
    public partial class CardsTileLayout
    {

    // Sample data for demonstration purposes
        private int dynamicColumns = 5;
        private string Cards_Tile_Title = "My Tile Layout";
        private List<TileData> tileDataList; // List to hold data for each TileLayoutItem
        // Sample class to represent TileData from JSON
        private class TileData
        {
            public string Content { get; set; }
        }

        // Load data from a JSON file (you can replace this with your actual data loading logic)
        protected override async Task OnInitializedAsync()
        {
            // Sample JSON data representing each TileLayoutItem
            var json = @"
        [
            { ""Content"": ""1 Text One"", ""OtherProperty"": ""Other Data 1"" },
            { ""Content"": ""2 Text Two"", ""OtherProperty"": ""Other Data 2"" },
            { ""Content"": ""3 Text Three"", ""OtherProperty"": ""Other Data 3"" },
            { ""Content"": ""4 Text Four"", ""OtherProperty"": ""Other Data 4"" },
            { ""Content"": ""5 Text Five"", ""OtherProperty"": ""Other Data 5"" }
        ]";

            tileDataList = JsonSerializer.Deserialize<List<TileData>>(json);
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
            builder.AddContent(10, "Baha Mestiri Testing Mode");
            builder.CloseElement();
            // Render the TelerikTileLayout
            builder.OpenComponent<TelerikTileLayout>(11);
            builder.AddAttribute(12, "Columns", dynamicColumns);
            builder.AddAttribute(13, "Class", "task-list1");
            builder.AddAttribute(14, "ColumnWidth", "3fr");
            builder.AddAttribute(15, "RowHeight", "3fr");
            builder.AddAttribute(16, "Resizable", true);
            builder.AddAttribute(17, "RowSpacing", "0px");
            builder.AddAttribute(18, "Reorderable", true);

            builder.AddAttribute(19, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                // Render multiple TileLayoutItems based on the data from the JSON file
                for (int i = 0; i < dynamicColumns && i < tileDataList.Count; i++)
                {
                    var tileData = tileDataList[i];
                    // Render a single TileLayoutItem
                    itemsBuilder.OpenComponent<TileLayoutItem>(20);
                    itemsBuilder.AddAttribute(21, "Class", "Child");

                    // Render the content (number + text) for each TileLayoutItem
                    itemsBuilder.AddAttribute(22, "Content", (RenderFragment)((contentBuilder) =>
                    {
                        contentBuilder.OpenElement(23, "br");
                        contentBuilder.CloseElement();

                        // Apply the orange color to the number
                        contentBuilder.OpenElement(24, "span");
                        contentBuilder.AddAttribute(25, "style", "color: orange; font-weight: bold;");
                        contentBuilder.AddContent(26, "number"); // Replace "number" with the actual number value
                        contentBuilder.CloseElement();
                        contentBuilder.OpenElement(27, "br");
                        contentBuilder.CloseElement();
                        contentBuilder.OpenElement(28, "br");
                        contentBuilder.CloseElement();
                        // Add the text content
                        contentBuilder.AddContent(29, $" {tileData.Content}");
                        contentBuilder.OpenElement(30, "br");
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

