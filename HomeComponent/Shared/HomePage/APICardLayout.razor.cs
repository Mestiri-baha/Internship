using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Telerik.Blazor.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class APICardLayout
    {
        // Sample class to represent data for ApiCard
        [Parameter]
        public string ImageUrl { get; set; }
        [Parameter]
        public List<string> Updates { get; set; }
        
        public APICardLayout apiCardData ; // Single ApiCardData instance

        // Load data from a JSON file (you can replace this with your actual data loading logic)
        protected override async Task OnInitializedAsync()
        {
            // Sample JSON data representing a single ApiCardData
            var json = @"
{
    ""ImageUrl"": ""https://via.placeholder.com/300.png/09f/fff"",
    ""Updates"": [
        ""Update 1 for ApiCard"",
        ""Update 2 for ApiCard"",
        ""Update 3 for ApiCard""
    ]
}";

        apiCardData = JsonSerializer.Deserialize<APICardLayout>(json);
        }

    private RenderFragment CreateApiCard() => builder =>
    {
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", "ApiCard");

        // Render the TelerikTileLayout
        builder.OpenComponent<TelerikTileLayout>(2);
        builder.AddAttribute(3, "Columns", 1);
        builder.AddAttribute(4, "Class", "apicard-style");
        builder.AddAttribute(5, "RowHeight", "600px");
        builder.AddAttribute(6, "ColumnWidth", "20rem");
        builder.AddAttribute(7, "Resizable", true);
        builder.AddAttribute(8, "Reorderable", true);

        // Render the single TileLayoutItem with the provided ApiCardData
        builder.OpenComponent<TileLayoutItem>(9);
        builder.AddAttribute(10, nameof(TileLayoutItem.RowSpan), 1);
        builder.AddAttribute(11, "HeaderTemplate", (RenderFragment)((headerBuilder) =>
        {
            builder.OpenElement(12, "img");
            builder.AddAttribute(13, "src", apiCardData.ImageUrl);
            builder.AddAttribute(14, "alt", "Image");
            builder.CloseElement();
        }));
        builder.AddAttribute(15, "Content", "baha");
        builder.CloseComponent();

        builder.CloseComponent(); // Close the TelerikTileLayout component
        builder.CloseElement(); // Close the <div class='ApiCard'> element
    };

}
}
