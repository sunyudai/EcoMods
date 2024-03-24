using Eco.Gameplay.Components;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(SmeltingSkill), 7)]
    public class DryTailingsProcessingRecipe : RecipeFamily
    {
        public DryTailingsProcessingRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "DryTailingsProcessing",  //noloc
                Localizer.DoStr("Dry Tailings Processing"),
                [
                    new IngredientElement(typeof(TailingsItem), 20, true), //noloc
                    new IngredientElement(typeof(CompostItem), 2, true), //noloc
                    new IngredientElement(typeof(DirtItem), 4, true), //noloc
                    new IngredientElement(typeof(PaperItem), 2, false) //noloc
                ],
                [
                    new CraftingElement<TailingsItem>(12),
                    new CraftingElement<WetTailingsItem>(2),
                    new CraftingElement<SandItem>(2),
                    new CraftingElement<CrushedSlagItem>(4),
                    new CraftingElement<CrushedMixedRockItem>(6),
                    new CraftingElement<CrushedIronOreItem>(2),
                    new CraftingElement<CrushedCopperOreItem>(1),
                    new CraftingElement<CrushedGoldOreItem>(1)
                ]);

            Recipes = [recipe];

            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(80, typeof(SmeltingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(DryTailingsProcessingRecipe), 4f, typeof(SmeltingSkill));

            Initialize(Localizer.DoStr("Dry Tailings Processing"), typeof(DryTailingsProcessingRecipe));
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }

    }
}
