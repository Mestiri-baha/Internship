using Blazored.LocalStorage;
using HomeComponent.Model;
using HomeComponent.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http.Headers;
using System.Text.Json;
using Telerik.Blazor.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class ButtonsLayout 
    {
        [Inject]
        public HomeUIService _Service { get; set; }

        private ILocalStorageService _localStorage ; 
       
        //for tomorrow : change the size of big container to 35% margin-left: 1rem; headerUI : margin-bottom: 0.5rem;
        HomeUIConfiguration data = new HomeUIConfiguration
        {
            Params = new List<Dictionary<string, object>>()
        };
        protected override async Task OnInitializedAsync()
        {
            
             data = await _Service.GetShortcutsAsync();
            Cache = await _localStorage.GetItemAsStringAsync(""); 

        }
        [Parameter] public int Columns { get; set; } 
        public void ButtonEventHandler(string url )
        {
            _Service.DoAction(url); 
        }
            private RenderFragment RenderButtonsLayout() => builder =>
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(1, "Class", "buttons");
            builder.OpenComponent<TelerikTileLayout>(2);
            builder.AddAttribute(3, "Columns", data.Params.Count);
            builder.AddAttribute(4, "RowHeight", "1fr"); // Set the RowHeight directly here or pass it as a parameter if needed
            builder.AddAttribute(5, "ColumnWidth", "1fr"); // Set the ColumnWidth directly here or pass it as a parameter if needed
            builder.AddAttribute(6, "Class", "Buttons-component");
            builder.AddAttribute(7, "Resizable", false);
            builder.AddAttribute(8, "Reorderable", true);
            builder.AddAttribute(9, "TileLayoutItems", (RenderFragment)((itemsBuilder) =>
            {
                int i = 0; 
                foreach (var items in data.Params)
                {
                    itemsBuilder.OpenComponent<TileLayoutItem>(10);
                    itemsBuilder.AddAttribute(22, "Content", (RenderFragment)((contentBuilder) =>
                    {
                        i++;
                        string colorName = items["color"].ToString();
                        contentBuilder.OpenElement(12, "div");
                        contentBuilder.AddAttribute(13, "style", "display: flex; flex-direction: column;");
                        contentBuilder.OpenElement(14, "h1");
                        contentBuilder.AddAttribute(15, "style", "font-size: 12px ; margin-bottom: 20px; font-weight: bold;");
                        contentBuilder.AddContent(16, items["label"]);
                        contentBuilder.CloseElement(); // Close the <h1> element
                        contentBuilder.OpenElement(17, "div");
                        contentBuilder.AddAttribute(18, "style", "display: flex ; flex-direction: column; gap: 20px; align-self: center;");
                    //List<Dictionary<string, object>> properties = new List<Dictionary<string, object>>(); 
                    //var properties = items.Values.Skip(2); 
                    var buttons = (JsonElement)items["button"];
                    if (buttons.ValueKind == JsonValueKind.Array)
                    {
                            foreach (var item in buttons.EnumerateArray())
                            {

                                //Console.WriteLine(item);
                                //List <Dictionary<string, object>> detail = new List <Dictionary<string, object>>();
                                //detail = (List<Dictionary<string, object>>)item;
                                //Console.WriteLine(detail[1].Values);
                                //foreach (var x in detail );
                                {
                                    contentBuilder.OpenElement(19, "button");
                                    contentBuilder.AddAttribute(20, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create(Columns,
                                    () => ButtonEventHandler(item.GetProperty("URL").GetString())));
                                    //contentBuilder.AddAttribute(21, "class", GetCustomButtonStyle(colorName));
                                    contentBuilder.AddAttribute(21, "class", "custom-button");
                                    contentBuilder.AddAttribute(21, "style", $"color: {colorName} ; border-color: {colorName} ;");
                                    contentBuilder.AddContent(23, item.GetProperty("label").GetString());
                                    contentBuilder.CloseElement(); //Close the <button> element

                                }
                            }
                            
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
