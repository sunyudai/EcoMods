using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Skills;
using Eco.Shared.Localization;

namespace Eco.Mods.TechTree
{

    [RequiresSkill(typeof(LoggingSkill), 5)]
    [Ecopedia("Items", "Fuels", subPageName: "Charcoal")]
    public class CrushedCoalToCharcoalRecipe : RecipeFamily
    {
        public CrushedCoalToCharcoalRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CrushedCoalToCharcoal",  //noloc
                Localizer.DoStr("Crushed Coal To Charcoal"),
                [
                	// 4 coal => 1 crushed coal
                
                    new IngredientElement(typeof(CrushedCoalItem), 3, typeof(LoggingSkill), typeof(LoggingLoggersLuckTalent)), //noloc 
					// 120,000 J * 3 = 240,000
                    new IngredientElement(typeof(PaperItem), 10, typeof(LoggingSkill), typeof(LoggingLoggersLuckTalent)) //noloc
					// 2,000 J ea * 5 = 10,000 J
                ],
                [
                    new CraftingElement<CharcoalItem>(40) // 10,000 J * 40 = 400,000 J
                ]);
            // INPUTS : -250,000 J = (240,000 J + 10,000 J)
            // OUTPUT :  400,000 J
            // TOTAL  : +150,000 J // TODO: Check math

            Recipes = [recipe];

            ExperienceOnCraft = 1;
            LaborInCalories = CreateLaborInCaloriesValue(110, typeof(LoggingSkill));
            CraftMinutes = CreateCraftTimeValue(typeof(CrushedCoalToCharcoalRecipe), .75f, typeof(LoggingSkill));

            Initialize(Localizer.DoStr("Crushed Coal To Charcoal"), typeof(CrushedCoalToCharcoalRecipe));
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }
    }
}
