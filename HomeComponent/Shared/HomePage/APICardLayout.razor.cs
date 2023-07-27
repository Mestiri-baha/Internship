using Microsoft.AspNetCore.Components;
using System.Text.Json;
using Telerik.Blazor.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class APICardLayout
    {
        // Sample class to represent data for ApiCard
        [Parameter] public string ImageUrl { get; set; } = "https://cms-cdn.placeholder.co/Vancouver_87c09f1b29.png?width=384 1x, https://cms-cdn.placeholder.co/Vancouver_87c09f1b29.png?width=750 2x";
        [Parameter] public List<string> Updates { get; set; }
        List<string> updates = new List<string> {
            "World Aquatics Championships: Ariarne Titmus and Leon Marchand break world records",
            "Leon Marchand snatches Michael Phelps' last world record at swimming worlds" };
        private RenderFragment CreateApiCard() => builder =>
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "ApiCard");
            builder.OpenComponent<TelerikTileLayout>(2);
            builder.AddAttribute(3, "Columns", 1);
            builder.AddAttribute(4, "Class", "apicard-style");
            builder.AddAttribute(5, "RowHeight", "600px");
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
                    headerBuilder.AddAttribute(15, "src", ImageUrl);
                    headerBuilder.AddAttribute(16, "alt", "Image");
                    headerBuilder.CloseElement();
                }));
                itemsBuilder.AddAttribute(17, "Content",RenderDynamicContent(updates)); 
                itemsBuilder.CloseComponent();

            }));
            builder.CloseComponent(); // Close the TelerikTileLayout component
            builder.CloseElement(); // Close the <div class='ApiCard'> element
        };
         public RenderFragment RenderDynamicContent(List<string> data) => builder => 
        {
            foreach(var item in data )
            {
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "style", "font-size: 14px;");
                builder.AddContent(2, item);
                builder.OpenElement(3, "hr");
                builder.CloseElement(); 
                builder.CloseElement();

            }
            builder.OpenElement(4, "Button");
            builder.AddAttribute(5, "style", "color : #0047AB ; border-color: #0047AB ; background-color:transparent");
            builder.AddContent(6, "Toutes Les Actualittés");
            builder.CloseElement(); 

        }; 

    }

}
