using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMouseRay : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    private bool isShown = false;
    private Transform transformLastContactObject;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out var hitInfo))
            {
                if(hitInfo.collider.gameObject.tag == "towerPos" && !isShown)
                {
                    for(int i = 0; i < hitInfo.transform.childCount; i++)
                    {
                        hitInfo.transform.GetChild(i).gameObject.SetActive(true);
                    }
                    isShown = !isShown;
                    transformLastContactObject =hitInfo.transform;
                }
                else if(hitInfo.collider.gameObject.tag == "towerPos" && isShown)
                {
                    for (int i = 0; i < hitInfo.transform.childCount; i++)
                    {
                        hitInfo.transform.GetChild(i).gameObject.SetActive(false);
                    }
                    isShown = !isShown;
                    transformLastContactObject = hitInfo.transform;
                }
                else if(hitInfo.collider.gameObject.tag == "towerType")
                {
                    for (int i = 0; i < transformLastContactObject.childCount; i++)
                    {
                        transformLastContactObject.GetChild(i).gameObject.SetActive(false);
                    }
                    Instantiate(hitInfo.transform.gameObject, new Vector3(transformLastContactObject.transform.position.x + 0.6f, transformLastContactObject.transform.position.y + 0.7f, transformLastContactObject.transform.position.z), transform.rotation).SetActive(true);
                }
            }
        }
    }
}
