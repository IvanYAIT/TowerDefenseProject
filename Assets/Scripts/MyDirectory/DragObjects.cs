using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragObjects : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] GameObject TowerPrefab;

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 1, Input.mousePosition.z));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.tag == "towerPos")
            {
                Instantiate(TowerPrefab, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z), transform.rotation);
            }
            else
            {
                Debug.Log("????????????????????????????????????????????????????????????????????????????????????????????????????.?.?,??.??????????????????????????????????????");
            }
        }
    }

    
}