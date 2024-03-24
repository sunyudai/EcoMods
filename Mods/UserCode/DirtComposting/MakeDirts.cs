using Eco.Gameplay.Components;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(FarmingSkill), 1)]
    public class MakeDirtRecipe : RecipeFamily
    {
        public MakeDirtRecipe()
        {
            Recipes =
            [
                new Recipe(
                      "Composting Into Dirt",
                      Localizer.DoStr("Composting Into Dirt"),
                      [
                          new IngredientElement(typeof(PlantFibersItem), 10, true),
                          new IngredientElement(typeof(DirtItem), 6, true),
                          new IngredientElement(typeof(CompostItem), 4, true)
                      ],
                      [
                          new CraftingElement<DirtItem>(8),
                          new CraftingElement<CompostItem>(2),
                          new CraftingElement<ClayItem>(1)
                      ]
                    )
            ];
            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(25, typeof(FarmingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(MakeDirtRecipe), 50f, typeof(FarmingSkill), typeof(FarmingFocusedSpeedTalent), typeof(FarmingParallelSpeedTalent));
            Initialize(Localizer.DoStr("Composting Into Dirt"), typeof(MakeDirtRecipe));
            CraftingComponent.AddRecipe(typeof(FarmersTableObject), this);
        }
    }
}
