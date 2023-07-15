using Microsoft.AspNetCore.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class FavorisLayout1
    {
        [Parameter]
        public string Title { get; set; } 
        [Parameter]
        public List<string> List_favoris { get; set; } = new List<string>();
        protected override async Task OnInitializedAsync()
        {
            
        }
    }
}
