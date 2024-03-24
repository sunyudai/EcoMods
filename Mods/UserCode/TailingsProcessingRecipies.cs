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
    [RequiresSkill(typeof(SmeltingSkill), 4)]
    public partial class WetTailingsDryingRecipe : RecipeFamily
    {
        public WetTailingsDryingRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "WetTailingsDrying",  //noloc
                Localizer.DoStr("Wet Tailings Drying"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(WetTailingsItem), 16, true), //noloc
                    new IngredientElement(typeof(CompostItem), 3, true), //noloc
                    new IngredientElement(typeof(SandItem), 3, true), //noloc
                    new IngredientElement(typeof(PaperItem), 2, false) //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<WetTailingsItem>(6),
                    new CraftingElement<TailingsItem>(6),
                    new CraftingElement<DirtItem>(2),
                    new CraftingElement<CompostItem>(1),
                    new CraftingElement<CrushedIronOreItem>(1),
                    new CraftingElement<CrushedCopperOreItem>(1),
                    new CraftingElement<CrushedGoldOreItem>(1)
                });

            this.Recipes = new List<Recipe> { recipe };

            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(40, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WetTailingsDryingRecipe), 3f, typeof(SmeltingSkill));

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wet Tailings Drying"), typeof(WetTailingsDryingRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(SmeltingSkill), 7)]
    public partial class DryTailingsProcessingRecipe : RecipeFamily
    {
        public DryTailingsProcessingRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "DryTailingsProcessing",  //noloc
                Localizer.DoStr("Dry Tailings Processing"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(TailingsItem), 20, true), //noloc
                    new IngredientElement(typeof(CompostItem), 2, true), //noloc
                    new IngredientElement(typeof(DirtItem), 4, true), //noloc
                    new IngredientElement(typeof(PaperItem), 2, false) //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<TailingsItem>(12),
                    new CraftingElement<WetTailingsItem>(2),
                    new CraftingElement<SandItem>(2),
                    new CraftingElement<CrushedSlagItem>(4),
                    new CraftingElement<CrushedMixedRockItem>(6),
                    new CraftingElement<CrushedIronOreItem>(2),
                    new CraftingElement<CrushedCopperOreItem>(1),
                    new CraftingElement<CrushedGoldOreItem>(1)
                });

            this.Recipes = new List<Recipe> { recipe };

            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(80, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(DryTailingsProcessingRecipe), 4f, typeof(SmeltingSkill));

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Dry Tailings Processing"), typeof(DryTailingsProcessingRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(SmeltingSkill), 7)]
    public partial class RollingSlagRecipe : RecipeFamily
    {
        public RollingSlagRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "RollingSlag",  //noloc
                Localizer.DoStr("Rolling Slag"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedSlagItem), 12, true), //noloc
                    new IngredientElement(typeof(CrushedMixedRockItem), 12, true)
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CrushedMixedRockItem>(10),
                    new CraftingElement<CrushedSlagItem>(10),
                    new CraftingElement<SandItem>(3),
                    new CraftingElement<DirtItem>(1),
                    new CraftingElement<ClayItem>(1),
                    new CraftingElement<CompostItem>(1)
                });

            this.Recipes = new List<Recipe> { recipe };

            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RollingSlagRecipe), 10f, typeof(SmeltingSkill));

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Rolling Slag"), typeof(RollingSlagRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [RequiresSkill(typeof(SmeltingSkill), 2)]
    public partial class RockSortingRecipe : RecipeFamily
    {
        public RockSortingRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Rock Sorting",  //noloc
                Localizer.DoStr("Rock Sorting"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CrushedMixedRockItem), 30, true)
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CrushedMixedRockItem>(20),
                    new CraftingElement<CrushedSlagItem>(2),
                    new CraftingElement<CrushedSandstoneItem>(1),
                    new CraftingElement<CrushedLimestoneItem>(2),
                    new CraftingElement<CrushedGraniteItem>(1),
                    new CraftingElement<CrushedShaleItem>(1),
                    new CraftingElement<CrushedGneissItem>(1),
                    new CraftingElement<CrushedBasaltItem>(1),
                    new CraftingElement<SandItem>(2)
                });

            this.Recipes = new List<Recipe> { recipe };

            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(RockSortingRecipe), 10f, typeof(SmeltingSkill));

            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Rock Sorting"), typeof(RockSortingRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
