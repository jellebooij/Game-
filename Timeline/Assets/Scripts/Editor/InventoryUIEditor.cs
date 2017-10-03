using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(InventoryUI))]
public class InventoryUIEditor : Editor {

    


    public override void OnInspectorGUI()
    {
        InventoryUI t = (InventoryUI)target;
        if (GUILayout.Button("Refresh"))
        {
            t.slotsRefresh();
        }
        base.OnInspectorGUI();
    }

}
