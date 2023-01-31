using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BSceneUI : MonoBehaviour
{
    public int clearCatAmount = 10;
    public int savedCatAmount = 0;

    private CatSpawner catSpawner;
    public Text leftCat;

    // Start is called before the first frame update
    void Start()
    {
        catSpawner = FindObjectOfType<CatSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clearCatAmount - savedCatAmount <= 0)
        {
            catSpawner.gameClear = true;
            leftCat.text = "0";
        }
        else
        {
            leftCat.text = (clearCatAmount - savedCatAmount).ToString();
        }
    }
}
