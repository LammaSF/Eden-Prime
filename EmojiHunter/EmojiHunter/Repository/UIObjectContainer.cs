namespace EmojiHunter.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using EmojiHunter.Contracts;

    public static class UIObjectContainer
    {
        private static Dictionary<ulong, IUIObject> uiObjectByID;

        static UIObjectContainer()
        {
            UIObjectContainer.uiObjectByID = new Dictionary<ulong, IUIObject>();
        }

        public static void AddUIObject(IUIObject uiObject)
        {
            UIObjectContainer.uiObjectByID.Add(uiObject.Sprite.ID, uiObject);
        }

        public static void RemoveUIObject(ulong uiObjectID)
        {
            UIObjectContainer.uiObjectByID.Remove(uiObjectID);
        }

        public static List<IUIObject> UIObjects =>
            UIObjectContainer.uiObjectByID.Select(s => s.Value).ToList();
    }
}
