using HomeComponent.Shared.HomePage;
using Microsoft.AspNetCore.Components;

namespace HomeComponent.Pages
{
    public partial class HomeUI 
    {
        public RenderFragment FavListRf;
        public RenderFragment FavEtatRf;
        protected  override async Task OnInitializedAsync()
        {
            FavListRf = GetFavList();
            FavEtatRf = CreateFavEtat(); 
        }

        protected RenderFragment GetFavList() => builder =>
       {
                    List<string> ListeFavoris = new List<string>() { "Etat de passif ", "Etat de L'actif", "Bilan" };
                    builder.OpenComponent(0, typeof(FavorisLayout1));
                    builder.AddAttribute(1, "Title", "Mes Listes des favoris");
                    builder.AddAttribute(2, "List_favoris", ListeFavoris);
                    builder.CloseComponent();
        };
        protected RenderFragment CreateFavEtat() => builder =>
        {
            List<string> ListeEtat = new List<string>() { "first", "second", "third","fourth","fifth"};
            builder.OpenComponent(0 , typeof(FavorisLayout2));
            builder.AddAttribute(1, "Fav_Title2", "Render_Fragment_is_validated");
            //My error was : adding the list element in the format of "string" :/ ! 
            //builder.AddAttribute(2, "Fav_List2", "ListeEtat");
            builder.AddAttribute(2, "Fav_List2", ListeEtat);
            builder.CloseComponent(); 
        }; 
    }
}
