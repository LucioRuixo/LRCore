using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace LRCore
{
    public class EditorShortcuts
    {
        [Shortcut("Window/Close", KeyCode.W, ShortcutModifiers.Action)]
        public static void CloseTab()
        {
            if (EditorWindow.focusedWindow) EditorWindow.focusedWindow.Close();
        }
    }
}