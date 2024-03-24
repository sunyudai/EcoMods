using Eco.Gameplay.Components;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(SmeltingSkill), 7)]
    public class RollingSlagRecipe : RecipeFamily
    {
        public RollingSlagRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "RollingSlag",  //noloc
                Localizer.DoStr("Rolling Slag"),
                [
                    new IngredientElement(typeof(CrushedSlagItem), 12, true), //noloc
                    new IngredientElement(typeof(CrushedMixedRockItem), 12, true)
                ],
                [
                    new CraftingElement<CrushedMixedRockItem>(10),
                    new CraftingElement<CrushedSlagItem>(10),
                    new CraftingElement<SandItem>(3),
                    new CraftingElement<DirtItem>(1),
                    new CraftingElement<ClayItem>(1),
                    new CraftingElement<CompostItem>(1)
                ]);

            Recipes = [recipe];

            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(20, typeof(SmeltingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(RollingSlagRecipe), 10f, typeof(SmeltingSkill));

            Initialize(Localizer.DoStr("Rolling Slag"), typeof(RollingSlagRecipe));
            CraftingComponent.AddRecipe(typeof(RockerBoxObject), this);
        }

    }
}
