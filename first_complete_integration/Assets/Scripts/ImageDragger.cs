using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageDragger : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{

    public static GameObject item_being_dragged;
    Transform my_parent;
    Vector2 my_pos;
    Image my_image;
    Color temp_color;
    float alpha_val = 0.5f;
    public void OnBeginDrag(PointerEventData eventData)
    {
        item_being_dragged = this.gameObject;
        my_pos = this.transform.position;
        my_parent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        temp_color.a = alpha_val;
        my_image.color = temp_color;
        transform.position = eventData.position;
        this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        if(transform.parent==my_parent)
        {

        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        item_being_dragged = null;
        temp_color.a = 1;
        my_image.color = temp_color;
        if(transform.parent == my_parent)
        {
            transform.position = my_pos;
        }
        else
        {
            transform.position = transform.parent.position;
        }
        this.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        my_image = this.GetComponent<Image>();
        temp_color = my_image.color;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
