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
    [RequiresSkill(typeof(LoggingSkill), 3)]
    [Ecopedia("Items", "Fuels", subPageName: "Charcoal")]
    public partial class CoalToCharcoalRecipe : RecipeFamily
    {
        public CoalToCharcoalRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CoalToCharcoal",  //noloc
                Localizer.DoStr("Coal To Charcoal"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CoalItem), 6, typeof(LoggingSkill), typeof(LoggingLoggersLuckTalent)), //noloc
					// 20,000 J * 6 = 120,000 J
                    new IngredientElement(typeof(PaperItem), 4, typeof(LoggingSkill), typeof(LoggingLoggersLuckTalent)) //noloc
					// 2,000 J ea * 6 = 12,000 J
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CharcoalItem>(12) // 20,000 J * 12 = 240,000 J
                });
            // INPUTS : -132,000 J = (120,000 J + 12,000 J)
            // OUTPUT :  240,000 J
            // TOTAL  : +108,000 J // 18,000 per coal

            this.Recipes = new List<Recipe> { recipe };

            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(90, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CoalToCharcoalRecipe), .5f, typeof(LoggingSkill));

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Coal To Charcoal"), typeof(CoalToCharcoalRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(LoggingSkill), 5)]
    [Ecopedia("Items", "Fuels", subPageName: "Charcoal")]
    public partial class CrushedCoalToCharcoalRecipe : RecipeFamily
    {
        public CrushedCoalToCharcoalRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CrushedCoalToCharcoal",  //noloc
                Localizer.DoStr("Crushed Coal To Charcoal"),
                new List<IngredientElement>
                {
                	// 4 coal => 1 crushed coal
                
                    new IngredientElement(typeof(CrushedCoalItem), 3, typeof(LoggingSkill), typeof(LoggingLoggersLuckTalent)), //noloc 
					// 120,000 J * 3 = 240,000
                    new IngredientElement(typeof(PaperItem), 10, typeof(LoggingSkill), typeof(LoggingLoggersLuckTalent)) //noloc
					// 2,000 J ea * 5 = 10,000 J
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CharcoalItem>(40) // 10,000 J * 40 = 400,000 J
                });
            // INPUTS : -250,000 J = (240,000 J + 10,000 J)
            // OUTPUT :  400,000 J
            // TOTAL  : +150,000 J // TODO: Check math

            this.Recipes = new List<Recipe> { recipe };

            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(110, typeof(LoggingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrushedCoalToCharcoalRecipe), .75f, typeof(LoggingSkill));

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Crushed Coal To Charcoal"), typeof(CrushedCoalToCharcoalRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
