using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GotoSlots : MonoBehaviour, IDropHandler
{
    public int my_index;

    public void Start()
    {
        
    }
    public GameObject item
    {
        get
        {
            if(transform.childCount>0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }

        
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(!item)
        {
            ActualIndex item_index = ImageDragger.item_being_dragged.transform.GetChild(0).GetComponent<ActualIndex>();
            my_index = numberPositionHandler.num_handler_instance.returnMyIndex(this.gameObject);

            if (item_index.actual_index == my_index)
            {
             
                ImageDragger.item_being_dragged.transform.SetParent(transform);
                numberPositionHandler.num_completed += 1;

            }
        }

    }
}
