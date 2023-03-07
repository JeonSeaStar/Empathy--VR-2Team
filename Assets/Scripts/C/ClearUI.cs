using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClearUI : MonoBehaviour
{
    public TextMeshProUGUI radioTMP;
    public GameObject Clear_Stamp;
    [TextArea] public string radioClearText;
    [TextArea] public string radioNClearText;

    void Awake()
    {
        Clear_Stamp.SetActive(false);                                          
        radioTMP.text = radioNClearText;
        ClearUi();
    }

    void ClearUi()
    {
        if (GameManager.instance.cmissionClear)
        {
            Clear_Stamp.SetActive(true);
            radioTMP.text = radioClearText;
        }
        else
        {
            Clear_Stamp.SetActive(false);
            radioTMP.text = radioNClearText;
        }
            
    }
}
