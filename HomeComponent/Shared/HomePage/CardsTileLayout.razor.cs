﻿using Microsoft.AspNetCore.Components;

namespace HomeComponent.Shared.HomePage
{
    public partial class CardsTileLayout
    {
        public partial class CardProperty
        {
            public int Cards_Tile_Value { get; set; }
            public String Cards_Tile_Label { get; set; }
            public CardProperty(string label ,  int number )
            {
                Cards_Tile_Value = number ;
                Cards_Tile_Label = label; 
            }
        }
        [Parameter]
        public String Cards_Tile_Title { get; set; }
        public List<CardProperty> CardProperties { get; set; } = new List<CardProperty>();

        protected override async Task OnInitializedAsync()
        {

        }


    }
}
