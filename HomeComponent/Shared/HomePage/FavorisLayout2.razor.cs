using Microsoft.AspNetCore.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class FavorisLayout2
    {
        [Parameter]
        public string Fav_Title2 { get; set ; }
        [Parameter]
        public Object Icon { get; set;  }
        // for now we will work as our list contains string as data type ! 
        [Parameter]
        public List<string> Fav_List2 { get; set;  } = new List<string>();
        protected override async Task OnInitializedAsync()
        {

        }
    }
}
