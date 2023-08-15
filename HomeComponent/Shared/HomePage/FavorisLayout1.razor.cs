using HomeComponent.Model;
using HomeComponent.Services;
using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using static Telerik.Blazor.ThemeConstants.Button;

namespace HomeComponent.Shared.HomePage
{
    public partial class FavorisLayout1
    {
        [Parameter] public string Title { get; set;  } = "My Tile Layout";
        [Inject]
        public HomeUIService _Service { get; set; }
        HomeUIConfiguration data = new HomeUIConfiguration
        {
            Params = new List<Dictionary<string, object>>()
        };
        protected override async Task OnInitializedAsync()
        {

            data = await _Service.GetFavouriteListAsync();

        }
        [Parameter] public List<string> List_favoris { get; set;  } = new List<string>
    {
        "Link 1",
        "Link 2",
        "Link 3",
        "Link 4",
        "Link 5"
    };
        private RenderFragment CreateListFavouriteContent() => builder =>
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
            builder.AddContent(9, " Fake Favourite List");
            builder.CloseElement(); // Close the <h1> element

            // Render the container div for the TelerikTileLayout
            builder.OpenElement(10, "div");
            builder.AddAttribute(11, "class", "FavorisHorizon");

            // Render the TelerikTileLayout
            builder.OpenComponent<TelerikTileLayout>(12);
            builder.AddAttribute(13, "Columns", 4); // Change this to use a variable if needed
            builder.AddAttribute(14, "RowHeight", "1fr");
            builder.AddAttribute(15, "ColumnWidth", "2fr");
            builder.AddAttribute(16, "Resizable", true);
            builder.AddAttribute(17, "Reorderable", true);
            builder.AddAttribute(18, "Class", "tile-items-style");

            // Render the TileLayoutItems based on the data from List_favoris
            builder.AddAttribute(19, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                foreach (var item in data.Params)
                {
                    itemsBuilder.OpenComponent<TileLayoutItem>(20);
                    itemsBuilder.AddAttribute(21, "HeaderText", "");
                    itemsBuilder.AddAttribute(22, "Content", (RenderFragment)((contentBuilder) =>
                    {
                        contentBuilder.OpenElement(23, "a");
                        contentBuilder.AddAttribute(24, "href", "#");
                        contentBuilder.AddAttribute(25, "style", "text-decoration: inherit; color: inherit");
                        contentBuilder.AddContent(26, item["label"]);
                        contentBuilder.CloseElement();
                    }));
                    itemsBuilder.CloseComponent();
                }
            }));

            builder.CloseComponent(); // Close the TelerikTileLayout component
            builder.CloseElement(); // Close the container div for the TelerikTileLayout
            builder.CloseElement(); // Close the <div class='CardsTile'> element
        };
    }
}

