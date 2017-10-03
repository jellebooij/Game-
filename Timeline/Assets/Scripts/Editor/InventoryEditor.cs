using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(Inventory))]
public class InventoryEditor : Editor {

    private SerializedProperty Slots;
    private SerializedProperty items;

    private bool[] showItemSlots = new bool[Inventory.numItemSlots];
    private bool hideSlots = false;

    private const string InventoryPropItemImagesName = "Slots";
    private const string InventoryPropItemsName = "items";

    private void OnEnable()
    {
        Slots = serializedObject.FindProperty(InventoryPropItemImagesName);
        items = serializedObject.FindProperty(InventoryPropItemsName);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUI.indentLevel++;

        Slots.arraySize = Inventory.numItemSlots;
        items.arraySize = Inventory.numItemSlots;


        space(2);

        EditorGUILayout.BeginVertical(GUI.skin.box);
        hideSlots = EditorGUILayout.Foldout(hideSlots, "Item slots");

        if (!hideSlots)
        {

            for (int i = 0; i < Inventory.numItemSlots; i++)
            {
                ItemSlotGui(i);
            }

        }
        EditorGUILayout.EndVertical();


        serializedObject.ApplyModifiedProperties();


        
    }

    private void ItemSlotGui(int index)
    {
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        showItemSlots[index] = EditorGUILayout.Foldout(showItemSlots[index], "Item slot " + index);
        
        
        if (showItemSlots[index])
        {
       
            EditorGUILayout.PropertyField(Slots.GetArrayElementAtIndex(index), new GUIContent("Slot")); 
            EditorGUILayout.PropertyField(items.GetArrayElementAtIndex(index), new GUIContent("Item"));
        }



        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
    }

    private void space(int spaces)
    {
        for(int i = 0; i < spaces; i++)
        {
            EditorGUILayout.Space();
        }

    }

}
