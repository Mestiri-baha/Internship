using HomeComponent.Shared.HomePage;
using Microsoft.AspNetCore.Components;

namespace HomeComponent.Pages
{
    public partial class HomeUI 
    {
        public RenderFragment FavListRf;
        protected  override async Task OnInitializedAsync()
        {
            FavListRf = GetFavList();
        }

        protected RenderFragment GetFavList() => builder =>
       {
                List<string> favritesEtas = new List<string>() { "Etat de passif ", "Etat de L'actif", "Bilan" };
                builder.OpenComponent(0, typeof(FavorisLayout1));
                    builder.AddAttribute(1, "Title", "Mes Listes des favoris");
                    builder.AddAttribute(2, "Etats", favritesEtas);
                builder.CloseComponent();
        };
    }
}
