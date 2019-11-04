using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class customHierarchy : MonoBehaviour
{

    private static Vector2 offset = new Vector2(20, 1);

    static customHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
    }

    private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {

        var obj = EditorUtility.InstanceIDToObject(instanceID);
        if(obj != null)
        {
            Color backgroundColor = Color.white;
            Color textColor = Color.white;
            Texture2D texture = null;
            
            //ADD CONDITIONS HERE TO COLOR MORE OBJECTS
            // YOU CAN COLOR FOLLOWING NAME, TAG...
            if (obj.name == "Player")
            {
                backgroundColor = new Color(0.2f, 0.6f, 0.1f);
                textColor = new Color(0.9f, 0.9f, 0.9f);
            }
            else if(obj.name == "Canvas")
            {
                backgroundColor = new Color(0.7f, 0.45f, 0.0f);
                textColor = new Color(0.9f, 0.9f, 0.9f);
            }

            if (backgroundColor != Color.white)
            {
                Rect offsetRect = new Rect(selectionRect.position + offset, selectionRect.size);
                Rect bgRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width + 50, selectionRect.height);

                EditorGUI.DrawRect(bgRect, backgroundColor);
                EditorGUI.LabelField(offsetRect, obj.name, new GUIStyle()
                {
                    normal = new GUIStyleState() { textColor = textColor },
                    fontStyle = FontStyle.Bold
                }
                );

                if(texture!= null)
                    EditorGUI.DrawPreviewTexture(new Rect(selectionRect.position, new Vector2(selectionRect.height, selectionRect.height)), texture);
            }
        }
    }
}
