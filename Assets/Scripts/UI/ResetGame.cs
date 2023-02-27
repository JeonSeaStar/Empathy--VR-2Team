using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public GameObject areYouReset;

    void Start()
    {
        areYouReset.SetActive(false);
    }

    public void OnResetButton()
    {
        areYouReset.SetActive(true);
    }

    public void OffResetButton()
    {
        areYouReset.SetActive(false);
    }
}
