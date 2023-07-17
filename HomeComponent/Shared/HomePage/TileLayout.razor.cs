using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class TileLayout
    {
        public partial  class Vignette {

            public String Header { get; set; }
            public String Content { get; set; }
        }
        [Parameter]
        public int numberofColumns { get; set; }
        [Parameter]
        public string Tile_layout_title { get; set; }
        [Parameter]
        public List<Vignette> childComponents { get; set; }  = new List<Vignette>();
        //we won't use it ! i think ! 
        
        private void RemoveChildComponent()
        {
            childComponents.Remove(childComponents.LastOrDefault());
            numberofColumns--;
            StateHasChanged();

        //API Data for the Content and HeaderText-- >
    
    }

    }
}
