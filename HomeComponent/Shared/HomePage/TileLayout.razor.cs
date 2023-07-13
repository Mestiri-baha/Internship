using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class TileLayout
    {
        private class ApiData {

            public String HeaderText { get; set; }
            public String Content { get; set; }


        }

        [Parameter]
        public int numberofColumns { get; set; }
        public List<TileLayoutItem> childComponents = new List<TileLayoutItem>();
        //we won't use it ! i think ! 
        private void AddChildComponent()
        {
            childComponents.Add(new TileLayoutItem());
            numberofColumns++;
            Console.WriteLine(MyColor);
            StateHasChanged();
        }
        private void RemoveChildComponent()
        {
            childComponents.Remove(childComponents.LastOrDefault());
            numberofColumns--;
            StateHasChanged();

        //API Data for the Content and HeaderText-- >
    
    }

    }
}
