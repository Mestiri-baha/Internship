using HomeComponent.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using Telerik.SvgIcons;
using static Telerik.Blazor.ThemeConstants.Button;

namespace HomeComponent.Shared.HomePage
{
    public partial class HomepageHeader
    {
        [Inject]
        public HomeUIService _Service { get; set; }
        [Parameter] public string user { get; set;  }

        protected override async Task OnInitializedAsync()
        {
           user =  await _Service.GetUserNameAsync();   

        }
    
    
        private RenderFragment RenderUserInfo()
        {
            RenderFragment fragment = builder =>
            {
                builder.OpenElement(0, "div");
                builder.AddAttribute(1, "style", "display: flex; justify-content: space-between; font-size: small;");

                // Render "Bienvenue @user"
                builder.OpenElement(2, "h6");
                builder.OpenComponent<TelerikFontIcon>(4);
                builder.AddAttribute(5, nameof(TelerikFontIcon.Icon), FontIcon.InfoCircle);
                builder.AddAttribute(6, nameof(TelerikFontIcon.Size), "md");
                builder.AddAttribute(7, nameof(TelerikFontIcon.Class), "custom-font-icon-class ");
                builder.AddAttribute(8, nameof(TelerikFontIcon.ThemeColor), ThemeColor.Base);
                builder.CloseComponent();
                builder.AddContent(3, "Bienvenue " + user);
                builder.CloseElement();

                // Render the right-side section with three h6 elements
                builder.OpenElement(4, "div");
                builder.AddAttribute(5, "style", "display: flex; gap: 26px;");

                // Render "Mon Compte Client"
                builder.OpenElement(6, "h6");
                builder.OpenComponent<TelerikFontIcon>(4);
                builder.AddAttribute(5, nameof(TelerikFontIcon.Icon), FontIcon.Unlock);
                builder.AddAttribute(6, nameof(TelerikFontIcon.Size), "md");
                builder.AddAttribute(7, nameof(TelerikFontIcon.Class), "custom-font-icon-class ");
                builder.AddAttribute(8, nameof(TelerikFontIcon.ThemeColor), ThemeColor.Base);
                builder.CloseComponent();
                builder.AddContent(7, "Mon Compte Client");
                builder.CloseElement();
                builder.OpenElement(8, "h6");
                builder.OpenElement(9, "a");
                builder.AddAttribute(10, "href", "http://salviadeveloppement.com");
                builder.AddAttribute(11, "style", "color : inherit ; text-decoration : none"); 
                builder.AddContent(12, "salviadeveloppement.com");
                builder.CloseElement();
                builder.CloseElement();
                // Render "Paramètres"
                builder.OpenElement(13, "h6");
                builder.OpenComponent<TelerikFontIcon>(4);
                builder.AddAttribute(14, nameof(TelerikFontIcon.Icon), FontIcon.Gear);
                builder.AddAttribute(15, nameof(TelerikFontIcon.Size), "md");
                builder.AddAttribute(16, nameof(TelerikFontIcon.Class), "custom-font-icon-class ");
                builder.AddAttribute(17, nameof(TelerikFontIcon.ThemeColor), ThemeColor.Base);
                builder.CloseComponent();
                builder.AddContent(18, "Paramètres");
                builder.CloseElement();

                builder.CloseElement(); // Close the div for the right-side section
                builder.CloseElement(); // Close the main div
            };

            return fragment;
        }

    }
}
