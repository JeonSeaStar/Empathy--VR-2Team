using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighLightRaycast : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public MeshRenderer[] meshRenderers;
    public Material[] material;

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var item in meshRenderers)
        {
            item.material = material[1];
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var item in meshRenderers)
        {
            item.material = material[0];
        }
    }

    public void OnMouseOver()
    {
        foreach (var item in meshRenderers)
        {
            item.material = material[1];
        }
    }

    public void OnMouseExit()
    {
        foreach (var item in meshRenderers)
        {
            item.material = material[0];
        }
    }
}
