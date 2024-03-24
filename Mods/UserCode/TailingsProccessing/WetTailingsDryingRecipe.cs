using Eco.Gameplay.Components;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(SmeltingSkill), 4)]
    public class WetTailingsDryingRecipe : RecipeFamily
    {
        public WetTailingsDryingRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "WetTailingsDrying",  //noloc
                Localizer.DoStr("Wet Tailings Drying"),
                [
                    new IngredientElement(typeof(WetTailingsItem), 16, true), //noloc
                    new IngredientElement(typeof(CompostItem), 3, true), //noloc
                    new IngredientElement(typeof(SandItem), 3, true), //noloc
                    new IngredientElement(typeof(PaperItem), 2, false) //noloc
                ],
                [
                    new CraftingElement<WetTailingsItem>(6),
                    new CraftingElement<TailingsItem>(6),
                    new CraftingElement<DirtItem>(2),
                    new CraftingElement<CompostItem>(1),
                    new CraftingElement<CrushedIronOreItem>(1),
                    new CraftingElement<CrushedCopperOreItem>(1),
                    new CraftingElement<CrushedGoldOreItem>(1)
                ]);

            Recipes = [recipe];

            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(40, typeof(SmeltingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(WetTailingsDryingRecipe), 3f, typeof(SmeltingSkill));

            Initialize(Localizer.DoStr("Wet Tailings Drying"), typeof(WetTailingsDryingRecipe));
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }
    }
}
