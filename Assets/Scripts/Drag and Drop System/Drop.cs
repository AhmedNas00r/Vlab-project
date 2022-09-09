using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler 
{
    
    private Image _image;
    [ColorHtmlProperty] public Color highlightColor;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().transform.position = GetComponent<RectTransform>().transform.position;
        eventData.pointerDrag.GetComponent<DragLabel>().SetDropped(true);
        eventData.pointerDrag.transform.SetParent(gameObject.transform);
        _image.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null)
            return;
        _image.color = highlightColor;
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.color = Color.white;
        Debug.Log("OnPointerExit");
    }
}
