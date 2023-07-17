using Microsoft.AspNetCore.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class CardLayout
    {
        [Parameter]
        public List<string> DynamicColumns { get; set; } = new List<String>();
        [Parameter]
        public string? CardLabel { get; set; } 
    }
}
