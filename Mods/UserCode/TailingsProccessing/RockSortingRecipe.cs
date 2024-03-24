using Eco.Gameplay.Components;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(SmeltingSkill), 2)]
    public class RockSortingRecipe : RecipeFamily
    {
        public RockSortingRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Rock Sorting",  //noloc
                Localizer.DoStr("Rock Sorting"),
                [
                    new IngredientElement(typeof(CrushedMixedRockItem), 30, true)
                ],
                [
                    new CraftingElement<CrushedMixedRockItem>(20),
                    new CraftingElement<CrushedSlagItem>(2),
                    new CraftingElement<CrushedSandstoneItem>(1),
                    new CraftingElement<CrushedLimestoneItem>(2),
                    new CraftingElement<CrushedGraniteItem>(1),
                    new CraftingElement<CrushedShaleItem>(1),
                    new CraftingElement<CrushedGneissItem>(1),
                    new CraftingElement<CrushedBasaltItem>(1),
                    new CraftingElement<SandItem>(2)
                ]);

            Recipes = [recipe];

            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(20, typeof(SmeltingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(RockSortingRecipe), 10f, typeof(SmeltingSkill));

            Initialize(Localizer.DoStr("Rock Sorting"), typeof(RockSortingRecipe));
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }

    }
}
