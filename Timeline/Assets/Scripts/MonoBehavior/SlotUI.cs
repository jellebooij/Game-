using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{


    public delegate void sentToInv(int i);
    public event sentToInv hover;


    Image img;
    Color startCol;

    public int index;

    [HideInInspector]
    public Color hoverColor;


    void Awake () {
        img = GetComponent<Image>();
        startCol = img.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.color = hoverColor;
        
        if(hover != null)
        {
            hover(index);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.color = startCol;
    }

    
  
	
	// Update is called once per frame
	void Update () {
		
	}
}
