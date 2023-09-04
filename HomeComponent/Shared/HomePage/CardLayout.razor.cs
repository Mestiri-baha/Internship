using HomeComponent.Model;
using HomeComponent.Services;
using Microsoft.AspNetCore.Components;
using System.Linq;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using static Telerik.Blazor.ThemeConstants.Button;

namespace HomeComponent.Shared.HomePage
{
    public partial class CardLayout
    {
        [Inject]
        public HomeUIService _Service { get; set; }
        HomeUIConfiguration data = new HomeUIConfiguration
        {
            Params = new List<Dictionary<string, object>>()
        };
        protected override async Task OnInitializedAsync()
        {

            data = await _Service.GetHistoryAsync();

        }

        public List<string> ColumnHeaders = new List<string>
        {
            "Date",
            "Type",
            "N°Fiche"
        };
        [Parameter]
        public string? CardLabel { get; set; }
        [Parameter]
        public List<List<string>> DataRows { get; set; }


private RenderFragment RenderDynamicTable()
        {
            return builder =>
            {
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "class", "Card");
                // Render the title
                builder.OpenElement(2, "h1");
                builder.AddAttribute(3, "style", "font-size: 14px; margin-left: 1rem; margin-bottom: 10px; margin-top: 10px; font-weight : bolder ;");
                //builder.OpenElement(3, "br");
                //builder.CloseElement();
                builder.OpenComponent<TelerikFontIcon>(4);
                builder.AddAttribute(5, nameof(TelerikFontIcon.Icon), FontIcon.Clock);
                builder.AddAttribute(6, nameof(TelerikFontIcon.Size), "md");
                builder.AddAttribute(7, nameof(TelerikFontIcon.Class), "custom-font-icon-class ");
                builder.AddAttribute(8, nameof(TelerikFontIcon.ThemeColor), ThemeColor.Success);
                builder.CloseComponent();
                builder.AddContent(9, "Dernières modifications");
                builder.CloseElement(); // Close the <h1> element
                                        // Render the table
                builder.OpenComponent<TelerikTileLayout>(5);
                builder.AddAttribute(6, "Columns", 2);
                builder.AddAttribute(7, "RowHeight", "1fr");
                builder.AddAttribute(8, "ColumnWidth", "2fr");
                builder.AddAttribute(9, "Resizable", false);
                builder.AddAttribute(10, "Reorderable", false);
                builder.AddAttribute(11, "Class", "cardlayout-style");
                builder.AddAttribute(10, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
                {
                    itemsBuilder.OpenElement(13, "TileLayoutItem");
                    itemsBuilder.AddAttribute(14, "class", "RemoveSpace");
                    itemsBuilder.AddAttribute(15, "ColSpan", 2);
                    itemsBuilder.AddAttribute(16, "RowSpan", 2);
                    itemsBuilder.OpenElement(17, "Content");
                    itemsBuilder.OpenElement(18, "div");
                    itemsBuilder.AddAttribute(19, "style", "margin-left: 10px; max-height: 170px;");
                    itemsBuilder.AddAttribute(20, "class", "table-scroll");
                    itemsBuilder.OpenElement(21, "table");
                    itemsBuilder.AddAttribute(22, "cellspacing", "4");
                    itemsBuilder.AddAttribute(23, "style", "width: 100%; border-collapse: separate; border-spacing: 0px 5px;");
                    // Render the table headers
                    itemsBuilder.OpenElement(24, "tr");

                    foreach (var columnHeader in ColumnHeaders)
                    {
                        itemsBuilder.OpenElement(25, "th");
                        itemsBuilder.AddAttribute(26, "Class", "th_style");

                        itemsBuilder.AddContent(27, columnHeader);
                        itemsBuilder.CloseElement();
                    }
                    itemsBuilder.CloseElement(); // Close the tr for headers
                                                 // Render the table data rows
                    foreach (Dictionary<string,object> rowData in data.Params)
                    {
                        itemsBuilder.OpenElement(27, "tr");
                        var action = rowData["Action"];
                        var numfiche = rowData["NumFiche"];
                        itemsBuilder.OpenElement(28, "td");
                        itemsBuilder.AddAttribute(29, "style", "font-weight: bolder ; font-size: 13px;");
                        itemsBuilder.AddContent(30, $"{rowData["date"]}");
                        itemsBuilder.CloseComponent();

                        foreach (var value in rowData.Values.Skip(1).Take(rowData.Values.Count-2))
                        {
                            int i = 0;
                            Console.WriteLine(value); 
                            itemsBuilder.OpenElement(28, "td");
                            itemsBuilder.AddAttribute(26, "Class", "td_style");
                            int test ;
                            bool success = int.TryParse(value.ToString(), out test);
                            if (test != 0)
                            {
                                itemsBuilder.OpenElement(27, "a");
                                //Action will be put here ! 
                                itemsBuilder.AddAttribute(28, "href", $"https://localhost:7194/HomeUI?action={action}&NumFiche={numfiche}");
                                itemsBuilder.AddAttribute(28, "Style", "font-weight: bold ;"); 
                                itemsBuilder.AddContent(28, value);
                                itemsBuilder.CloseComponent();

                            }
                            else { 
                            itemsBuilder.AddContent(29, value);
                        }
                            itemsBuilder.CloseElement();
                        }
                        itemsBuilder.CloseElement(); // Close the tr for data row
                    }

                    itemsBuilder.CloseElement(); // Close the table
                    itemsBuilder.CloseElement(); // Close the div with class="table-scroll"
                    itemsBuilder.CloseElement(); // Close the Content
                    itemsBuilder.CloseElement(); // Close the TileLayoutItem
                }));
                
                builder.CloseElement(); // Close the TelerikTileLayout
                builder.CloseElement(); // Close the RenderFragment root div
            };
        }

    }
}
