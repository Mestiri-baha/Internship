using HomeComponent.Shared.HomePage;
using Microsoft.AspNetCore.Components;
using static HomeComponent.Shared.HomePage.CardsTileLayout;
using static HomeComponent.Shared.HomePage.TileLayout;

namespace HomeComponent.Pages
{
    public partial class HomeUI 
    {
        public RenderFragment FavListRf;
        public RenderFragment FavEtatRf;
        public RenderFragment Controls;
        public RenderFragment CardDynamic;
        public RenderFragment Vignettes; 
        protected  override async Task OnInitializedAsync()
        {
            FavListRf = GetFavList();
            FavEtatRf = CreateFavEtat();
            Controls = DisplayControls();
            CardDynamic = renderCard();
            Vignettes = createVignettes(); 
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
           
            List<string> ListeEtat = new List<string>() { "first",  "third","fourth","fifth"};
            builder.OpenComponent(0 , typeof(FavorisLayout2));
            builder.AddAttribute(1, "Fav_Title2", "Render_Fragment_is_validated");
            //My error was : adding the list element in the format of "string" :/ ! 
            //builder.AddAttribute(2, "Fav_List2", "ListeEtat");
            builder.AddAttribute(2, "Fav_List2", ListeEtat);
            builder.CloseComponent(); 
        };
        protected RenderFragment DisplayControls() => _builder =>
        {
            List<CardProperty> GenericList = new List<CardProperty>
            {
                new CardProperty("first",0),
                new CardProperty("second",2),
                new CardProperty("third",3),
};      
            _builder.OpenComponent(0, typeof(CardsTileLayout));
            _builder.AddAttribute(1, "Cards_Tile_Title", "GenericData");
           
            _builder.CloseComponent();

        };
        protected RenderFragment renderCard() => builder =>
        {

            List<string> listcolumns = new List<string>() { "column1", "column2", "column3", "column4" };
            builder.OpenComponent(0, typeof(CardLayout));
            builder.AddAttribute(1, "CardLabel", "Dynamic card");
            
            builder.AddAttribute(2, "DynamicColumns", listcolumns);
            builder.CloseComponent();
        };
        protected RenderFragment createVignettes() => builder =>
        {
            //for testing 
            List<Vignette> listeVignettes = new List<Vignette>
            {
                new Vignette { Content="first", Header="Icon+colour"}
            };
            int count = listeVignettes.Count(); 
            builder.OpenComponent(0, typeof(TileLayout));
            builder.AddAttribute(0, "numberofColumns", count); 
            builder.AddAttribute(1, "Tile_layout_title", "Liste des vignettes");
            builder.AddAttribute(2, "childComponents", listeVignettes);
            builder.CloseComponent();
        };
    }
}
