using HomeComponent.Model;
using HomeComponent.Services;
using Microsoft.AspNetCore.Components;
using System.Drawing;
using Telerik.Blazor.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class ButtonsLayout 
    {
        [Inject]
        public HomeUIService _Service { get; set; }
        //for tomorrow : change the size of big container to 35% margin-left: 1rem; headerUI : margin-bottom: 0.5rem;
        HomeUIConfiguration data = new HomeUIConfiguration
        {
            Params = new List<Dictionary<string, object>>()
        };
        protected override async Task OnInitializedAsync()
        {
            
             data = await _Service.GetShortcutsAsync();    

        }
        [Parameter] public int Columns { get; set; } 
        [Parameter] public List<TileLayoutItemData> TileLayoutItemsData { get; set; }

        public class TileLayoutItemData
        {
            public string GroupTitle { get; set; }
            public string ButtonColor { get; set; }
            public List<string> Tasks { get; set; }
        }
        List<ButtonsLayout.TileLayoutItemData> testData = new List<ButtonsLayout.TileLayoutItemData>
{
    new ButtonsLayout.TileLayoutItemData
    {
        GroupTitle = "Group 1",
        ButtonColor = "red",
        Tasks = new List<string>
        {
            "Task 1",
            "Task 2",
        }
    },
    new ButtonsLayout.TileLayoutItemData
    {
        GroupTitle = "Group 2",
        ButtonColor = "blue",
        Tasks = new List<string>
        {
            "Task A",
            "Task B",
        }
    },
    
};
        private RenderFragment RenderButtonsLayout() => builder =>
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "class", "buttons");
            // Render the TelerikTileLayout
            builder.OpenComponent<TelerikTileLayout>(2);
            builder.AddAttribute(3, "Columns", data.Params.Count);
            builder.AddAttribute(4, "RowHeight", "1fr"); // Set the RowHeight directly here or pass it as a parameter if needed
            builder.AddAttribute(5, "ColumnWidth", "1fr"); // Set the ColumnWidth directly here or pass it as a parameter if needed
            builder.AddAttribute(6, "Class", "Buttons-component");
            builder.AddAttribute(7, "Resizable", false);
            builder.AddAttribute(8, "Reorderable", true);
            builder.AddAttribute(9, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                foreach (var items in data.Params)
                {
                    itemsBuilder.OpenComponent<TileLayoutItem>(10);
                    itemsBuilder.AddAttribute(22, "Content", (RenderFragment)((contentBuilder) =>
                    {
                        contentBuilder.OpenElement(12, "div");
                        contentBuilder.AddAttribute(13, "style", "display: flex; flex-direction: column;");
                        contentBuilder.OpenElement(14, "h1");
                        contentBuilder.AddAttribute(15, "style", "font-size: 12px ; margin-bottom: 20px; font-weight: bold;");
                        contentBuilder.AddContent(16, items["label"]);
                        contentBuilder.CloseElement(); // Close the <h1> element
                        contentBuilder.OpenElement(17, "div");
                        contentBuilder.AddAttribute(18, "style", "display: flex; flex-direction: column; gap: 20px; align-self: center;");
                        foreach (var item in ((items.Values).Skip(1)))
                        {
                            contentBuilder.OpenElement(19, "button");
                            contentBuilder.AddAttribute(20, "href", "#");
                            contentBuilder.AddAttribute(21, "class", "custom-button");
                            contentBuilder.AddAttribute(22, "style", $"color: {Color.Green} !important; border-color: {Color.Green};");
                            contentBuilder.AddContent(23, "test");
                            contentBuilder.CloseElement(); // Close the <button> element
                        }
                       
                        
                        contentBuilder.CloseElement(); // Close the <div> element
                        contentBuilder.CloseElement(); // Close the <div> element

                    })); 
                        itemsBuilder.CloseElement(); // Close the <TileLayoutItem> element
                }
            }));
            builder.CloseComponent(); // Close the <TelerikTileLayout> element
            builder.CloseElement(); // Close the <div class="buttons"> element
        };
       

    }

}
