using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{
    [RequiresSkill(typeof(LoggingSkill), 3)]
    [Ecopedia("Items", "Fuels", subPageName: "Charcoal")]
    public class CoalToCharcoalRecipe : RecipeFamily
    {
        public CoalToCharcoalRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CoalToCharcoal",  //noloc
                Localizer.DoStr("Coal To Charcoal"),
                [
                    new IngredientElement(typeof(CoalItem), 6, typeof(LoggingSkill), typeof(LoggingLoggersLuckTalent)), //noloc
					// 20,000 J * 6 = 120,000 J
                    new IngredientElement(typeof(PaperItem), 4, typeof(LoggingSkill), typeof(LoggingLoggersLuckTalent)) //noloc
					// 2,000 J ea * 6 = 12,000 J
                ],
                [
                    new CraftingElement<CharcoalItem>(12) // 20,000 J * 12 = 240,000 J
                ]);
            // INPUTS : -132,000 J = (120,000 J + 12,000 J)
            // OUTPUT :  240,000 J
            // TOTAL  : +108,000 J // 18,000 per coal

            Recipes = [recipe];

            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(90, typeof(LoggingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(CoalToCharcoalRecipe), .5f, typeof(LoggingSkill));

            Initialize(Localizer.DoStr("Coal To Charcoal"), typeof(CoalToCharcoalRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}
