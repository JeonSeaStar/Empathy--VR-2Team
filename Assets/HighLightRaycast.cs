using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighLightRaycast : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public MeshRenderer[] meshRenderers;
    public Material[] material;
    public GameObject origin;
    public GameObject highlight;

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var item in meshRenderers)
        {
            item.material = material[1];
        }
        //origin.SetActive(false);
        //highlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var item in meshRenderers)
        {
            item.material = material[0];
        }
        //origin.SetActive(true);
        //highlight.SetActive(false);
    }

    //public void OnMouseOver()
    //{
    //    foreach (var item in meshRenderers)
    //    {
    //        item.material = material[1];
    //    }
    //}

    //public void OnMouseExit()
    //{
    //    foreach (var item in meshRenderers)
    //    {
    //        item.material = material[0];
    //    }
    //}
}
