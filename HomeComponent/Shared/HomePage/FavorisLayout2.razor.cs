using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using static Telerik.Blazor.ThemeConstants.Button;

namespace HomeComponent.Shared.HomePage
{
    public partial class FavorisLayout2
    {
        [Parameter]  public  string Fav_Title2 { get; set;  } = "My Tile Layout 2";
         [Parameter] public List<string> Fav_List2 { get; set;  } = new List<string>
    {
        "etat 1",
        "etat 2",
        "etat 3",
        "etat 4",
        "etat 5"
    };
        private RenderFragment CreateStateListContent() => builder =>
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "favourite");
            // Render the title
            builder.OpenElement(2, "h1");
            builder.AddAttribute(3, "style", "font-size: medium; margin-top: 20px; margin-left: 1rem; margin-bottom: 22px;");
            builder.OpenElement(3, "br");
            builder.CloseElement();
            builder.OpenComponent<TelerikFontIcon>(4);
            builder.AddAttribute(5, nameof(TelerikFontIcon.Icon), FontIcon.Star);
            builder.AddAttribute(6, nameof(TelerikFontIcon.Size), "md");
            builder.AddAttribute(7, nameof(TelerikFontIcon.Class), "custom-font-icon-class ");
            builder.AddAttribute(8, nameof(TelerikFontIcon.ThemeColor), ThemeColor.Warning);
            builder.CloseComponent();
            builder.AddContent(9, " Fake Favourite State");
            builder.CloseElement(); // Close the <h1> element
            // Render the container div for the TelerikTileLayout
            builder.OpenElement(4, "div");
            builder.AddAttribute(5, "class", "FavorisHorizon2");
            // Render the TelerikTileLayout
            builder.OpenComponent<TelerikTileLayout>(6);
            builder.AddAttribute(7, "Columns", 4);
            builder.AddAttribute(8, "Class", "tile-items-style2");
            builder.AddAttribute(9, "RowHeight", "1fr");
            builder.AddAttribute(10, "ColumnWidth", "2fr");
            builder.AddAttribute(11, "Resizable", true);
            builder.AddAttribute(12, "Reorderable", true);

            // Render the TileLayoutItems based on the data from Fav_List2
            builder.AddAttribute(13, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                foreach (var item in Fav_List2)
                {
                    itemsBuilder.OpenComponent<TileLayoutItem>(14);
                    itemsBuilder.AddAttribute(15, "HeaderText", "");
                    itemsBuilder.AddAttribute(16, "Content", (RenderFragment)((contentBuilder) =>
                    {
                        contentBuilder.OpenElement(17, "a");
                        contentBuilder.AddAttribute(18, "href", "#");
                        contentBuilder.AddAttribute(19, "style", "text-decoration: inherit; color: inherit");
                        contentBuilder.AddContent(20, item);
                        contentBuilder.CloseElement();
                    }));
                    itemsBuilder.CloseComponent();
                }
            }));

            builder.CloseComponent(); // Close the TelerikTileLayout component
            builder.CloseElement(); // Close the container div for the TelerikTileLayout
            builder.CloseElement(); // Close the <div> element
        };
    }



}
    

