using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearUI : MonoBehaviour
{
    public TextMeshProUGUI radioTMP;
    public SpriteRenderer Clear_Stamp;
    [TextArea] public string radioClearText;
    [TextArea] public string radioNClearText;

    void Awake()
    {
        Clear_Stamp.enabled = false;
        ClearUi();
    }

    void ClearUi()
    {
        if (GameManager.instance.cmissionClear)
        {
            Clear_Stamp.enabled = true;
            radioTMP.text = radioClearText;
        }
        else
        {
            Clear_Stamp.enabled = false;
            radioTMP.text = radioClearText;
        }
            
    }
}
