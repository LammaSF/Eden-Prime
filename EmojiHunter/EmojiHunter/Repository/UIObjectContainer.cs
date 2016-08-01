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
            lock (uiObjectByID)
            {
                UIObjectContainer.uiObjectByID.Add(uiObject.Sprite.ID, uiObject);
            }
        }

        public static void RemoveUIObject(ulong uiObjectID)
        {
            lock (uiObjectByID)
            {
                UIObjectContainer.uiObjectByID.Remove(uiObjectID);
            }
        }

        public static List<IUIObject> UIObjects
        {
            get
            {
                lock (uiObjectByID)
                {
                    return uiObjectByID.Select(s => s.Value).ToList();
                }
            }
        }

        public static void Reset()
        {
            uiObjectByID = new Dictionary<ulong, IUIObject>();
        }
    }
}
