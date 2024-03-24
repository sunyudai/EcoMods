using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.World;
using Eco.World.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(FarmingSkill), 1)]
    public partial class MakeDirtRecipe : RecipeFamily
    {
        public MakeDirtRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                      "Composting Into Dirt",
                      Localizer.DoStr("Composting Into Dirt"),
                      new IngredientElement[]
                      {
                          new IngredientElement(typeof(PlantFibersItem), 10, true),
                          new IngredientElement(typeof(DirtItem), 6, true),
                          new IngredientElement(typeof(CompostItem), 4, true)
                      },
                      new CraftingElement[]
                      {
                          new CraftingElement<DirtItem>(8),
                          new CraftingElement<CompostItem>(2),
                          new CraftingElement<ClayItem>(1)
                      }
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FarmingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MakeDirtRecipe), 50f, typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Composting Into Dirt"), typeof(MakeDirtRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
