using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LRCore.Editor.Utils
{
    using SOs;

    public class ScriptableWindow : EditorWindow
    {
        protected virtual bool AddToHierarchy => true;

        private ScriptableObject TargetObject { get; set; }
        private UnityEditor.Editor CustomEditor { get; set; }

        private Vector2 scrollPos;

        private List<ScriptableObject> TargetObjects { get; set; } = new List<ScriptableObject>();

        public static void Open(ScriptableObject scriptableObject)
        {
            ScriptableWindow window = (ScriptableWindow)GetWindow(typeof(ScriptableWindow), false);
            if (!window) return;

            window.SetTargetObject(scriptableObject);
        }

        protected virtual void OnGUI()
        {
            EditorGUIUtility.labelWidth = 200.0f;

            if (CustomEditor)
            {
                if (AddToHierarchy)
                {
                    DrawObjectHierarchy();

                    EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
                }

                scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
                CustomEditor.OnInspectorGUI();
                EditorGUILayout.EndScrollView();
            }
        }

        private void DrawObjectHierarchy()
        {
            EditorGUILayout.BeginHorizontal();

            foreach (var targetObj in TargetObjects)
            {
                if (GUILayout.Button(targetObj.name, GUILayout.Width(targetObj.name.Length * 9.0f)))
                {
                    Open(targetObj);
                    return;
                }
            }

            GUILayout.EndHorizontal();
        }

        protected void SetTargetObject(ScriptableObject targetObject)
        {
            TargetObject = targetObject;
            CustomEditor = UnityEditor.Editor.CreateEditor(targetObject);
            titleContent = new GUIContent(targetObject.name);

            if (!AddToHierarchy) return;

            // Keep a record of the setting objects hierarchy
            int newTargetObjIndex = TargetObjects.IndexOf(targetObject);
            if (newTargetObjIndex >= 0)
            {
                // Showing an object from the hierarchy -> remove all elements in front of it
                TargetObjects.RemoveRange(newTargetObjIndex + 1, TargetObjects.Count - (newTargetObjIndex + 1));
            }
            else
            {
                // Showing a new object -> Add it to the list
                TargetObjects.Add(targetObject);
            }
        }
    }

    [CustomPropertyDrawer(typeof(CustomScriptableObject), true)]
    public class CustomScriptableObjectDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => 0.0f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PropertyField(property, label, true);
            if (GUILayout.Button("VER", GUILayout.Width(40))) ScriptableWindow.Open((ScriptableObject)property.objectReferenceValue);

            GUILayout.EndHorizontal();
        }
    }
}