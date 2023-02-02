using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BSceneUI : MonoBehaviour
{
    public int clearCatAmount = 5;
    public int savedCatAmount = 0;

    public Text leftCat;

    public GameObject fade;
    public Animator fadeAni;

    private bool isFade = true;

    private void Start()
    {
        isFade = true;
        fade.SetActive(false);
        fadeAni = fade.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clearCatAmount - savedCatAmount <= 0)
        {
            GameManager.instance.bmissionClear = true;
            leftCat.text = "0";
        }
        else
        {
            leftCat.text = (clearCatAmount - savedCatAmount).ToString();
        }

        if (GameManager.instance.bmissionClear && isFade)
        {
            fade.SetActive(true);
            StartCoroutine(FadeOut());
        }
    } 

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2.0f);
        
        fadeAni.SetTrigger("FadeOut");
        isFade = false;
    }

    private void OnApplicationQuit()
    {
        StopCoroutine(FadeOut());
    }
}
