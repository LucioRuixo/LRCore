using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LRCore
{
    public class ScriptableWindow : EditorWindow
    {
        // TODO: estudiar esta clase

        private ScriptableObject TargetObject { get; set; }
        private Editor CustomEditor { get; set; }

        private Vector2 scrollPos;

        private List<ScriptableObject> TargetObjects { get; set; } = new List<ScriptableObject>();

        public static void Open(ScriptableObject so)
        {
            // ScriptableWindow window = CreateInstance(typeof(ScriptableWindow)) as ScriptableWindow;
            // if(window == null) return;
            // window.SetTargetObject(so);
            // window.ShowUtility();

            ScriptableWindow window = (ScriptableWindow)GetWindow(typeof(ScriptableWindow), false);
            if (!window) return;
            window.SetTargetObject(so);
        }

        private void SetTargetObject(ScriptableObject targetObject)
        {
            TargetObject = targetObject;
            CustomEditor = Editor.CreateEditor(targetObject);
            titleContent = new GUIContent(targetObject.name);

            // Keep a record of the setting objects hierarchy
            int newTargetObjIdx = TargetObjects.IndexOf(targetObject);
            if (newTargetObjIdx >= 0)
            {
                // Showing an object from the hierarchy -> remove all elements in front of it
                TargetObjects.RemoveRange(newTargetObjIdx + 1, TargetObjects.Count - (newTargetObjIdx + 1));
            }
            else
            {
                // Showing a new object -> Add it to the list
                TargetObjects.Add(targetObject);
            }
        }

        void OnGUI()
        {
            EditorGUIUtility.labelWidth = 200.0f;

            if (CustomEditor)
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

                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

                scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
                CustomEditor.OnInspectorGUI();
                EditorGUILayout.EndScrollView();
            }
        }
    }

    [CustomPropertyDrawer(typeof(ScriptableObject), true)]
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