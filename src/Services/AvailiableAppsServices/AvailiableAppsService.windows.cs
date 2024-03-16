namespace PolyhydraGames.Core.Console.Services.AvailiableAppsServices
{
    public class AvailiableAppsService : IAvailiableAppsService
    {
        //public bool IsAppInstalled(string app)
        //{
        //    switch (app)
        //    {
        //        case "PFAssistant":
        //            return IsAppInstalled("com.polyhydragames.pathfinderpaid");
        //        case "PFCraftingCalculator":
        //            return IsAppInstalled("com.polyhydragames.PFCraftingCalculator");
        //        case "PFGrimoire":
        //            return IsAppInstalled("com.polyhydragames.PFSpellbookCalculator");
        //        case "PFLootRoller":
        //            return IsAppInstalled("com.polyhydragames.PFLootRoller");
        //    }

        //    return false;
        //}

        private bool IsAppInstalled(string uri)
        {
            bool appInstalled = false;

            return appInstalled;
        }

        public bool IsAppInstalled(Enum app)
        {
            throw new NotImplementedException();
        }
    }
}