using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearUI : MonoBehaviour
{
    public TextMeshProUGUI radioTMP;
    [TextArea] public string radioClearText;
    [TextArea] public string radioNClearText;

    void Awake()
    {
        ClearUi();
    }

    void ClearUi()
    {
        if (GameManager.instance.cmissionClear)
            radioTMP.text = radioClearText;
        else
            radioTMP.text = radioNClearText;
    }
}
