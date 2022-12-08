using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragObjects : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] GameObject TowerPrefab;
    [SerializeField] Transform parent;
    [SerializeField] Text Text;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.tag == "towerPos")
            {
                Tower towerInfo = TowerPrefab.GetComponent<Tower>();
                if (ResourceManager.Instance.money >= towerInfo.Cost)
                {
                    GameObject obj = Instantiate(TowerPrefab, new Vector3(hit.transform.position.x, hit.transform.position.y + 1.5f, hit.transform.position.z), hit.transform.rotation);
                    obj.GetComponent<Tower>().SetTextMoney(Text);
                    ResourceManager.Instance.money -= towerInfo.Cost;
                }

            }
            else
            {
                Debug.Log("????????????????????????????????????????????????????????????????????????????????????????????????????.?.?,??.??????????????????????????????????????");
            }
            
        }
        transform.position = startPosition;
    }

    
}
