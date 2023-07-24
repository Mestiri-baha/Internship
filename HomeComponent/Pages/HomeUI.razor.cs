using HomeComponent.Shared.HomePage;
using Microsoft.AspNetCore.Components;
using static HomeComponent.Shared.HomePage.CardsTileLayout;
using static HomeComponent.Shared.HomePage.TileLayout;

namespace HomeComponent.Pages
{
    public partial class HomeUI 
    {
        public RenderFragment CardDynamic;
        protected  override async Task OnInitializedAsync()
        {
            CardDynamic = renderCard();
        }


        protected RenderFragment renderCard() => builder =>
        {

            List<string> listcolumns = new List<string>() { "column1", "column2", "column3", "column4" };
            builder.OpenComponent(0, typeof(CardLayout));
            builder.AddAttribute(1, "CardLabel", "Dynamic card");
            
            builder.AddAttribute(2, "DynamicColumns", listcolumns);
            builder.CloseComponent();
        };
    }
}
