using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighLightRaycastTV : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer[] meshRenderers;
    public Material[] material;

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var item in meshRenderers)
        {
            item.materials[0] = material[1];
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var item in meshRenderers)
        {
            item.materials[0] = material[0];
        }
    }
}
