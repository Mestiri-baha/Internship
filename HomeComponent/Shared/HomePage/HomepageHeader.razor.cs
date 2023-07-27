using Microsoft.AspNetCore.Components;
using Telerik.Blazor.Components;
using Telerik.FontIcons;
using static Telerik.Blazor.ThemeConstants.Button;

namespace HomeComponent.Shared.HomePage
{
    public partial class HomepageHeader
    {
        [Parameter] public string user { get; set;  }
        private RenderFragment RenderUserInfo(string user)
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
                builder.AddContent(9, "Salviedeveloppement.com");
                builder.CloseElement();
                // Render "Paramètres"
                builder.OpenElement(10, "h6");
                builder.OpenComponent<TelerikFontIcon>(4);
                builder.AddAttribute(5, nameof(TelerikFontIcon.Icon), FontIcon.Gear);
                builder.AddAttribute(6, nameof(TelerikFontIcon.Size), "md");
                builder.AddAttribute(7, nameof(TelerikFontIcon.Class), "custom-font-icon-class ");
                builder.AddAttribute(8, nameof(TelerikFontIcon.ThemeColor), ThemeColor.Base);
                builder.CloseComponent();
                builder.AddContent(11, "Paramètres");
                builder.CloseElement();

                builder.CloseElement(); // Close the div for the right-side section
                builder.CloseElement(); // Close the main div
            };

            return fragment;
        }

    }
}
