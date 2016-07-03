﻿using System.Collections.Generic;
using System.Linq;

namespace EmojiHunter.UIComponents
{
    public static class UIObjectContainer
    {
        private static Dictionary<ulong, IUIObject> UIObjectByID;

        static UIObjectContainer()
        {
            UIObjectContainer.UIObjectByID = new Dictionary<ulong, IUIObject>();
        }

        public static void AddUIObject(IUIObject uiObject)
        {
            UIObjectContainer.UIObjectByID.Add(uiObject.Sprite.ID, uiObject);
        }

        public static void RemoveSprite(IUIObject uiObject)
        {
            UIObjectContainer.UIObjectByID.Remove(uiObject.Sprite.ID);
        }

        public static IEnumerable<IUIObject> UIObjects =>
            UIObjectContainer.UIObjectByID.Select(s => s.Value);
    }
}