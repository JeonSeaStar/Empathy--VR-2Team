using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using OVR;
using Oculus;
using OculusSampleFramework;
using System.Collections;

public class LodingSceneManager : MonoBehaviour
{
    public static string nextScene;
    public static string toolTip;
    [SerializeField] TMP_Text anyText;
    [SerializeField] GameObject start;
    [SerializeField] GameObject back;
    [SerializeField] Image progressBar;
    [SerializeField] Image aimage;
    [SerializeField] Image bimage;
    [SerializeField] Image cimage;
    [SerializeField] GameObject agameObject;
    [SerializeField] GameObject bgameObject;
    [SerializeField] GameObject cgameObject;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName, string toolTipName)
    {
        nextScene = sceneName;
        toolTip= toolTipName;
        SceneManager.LoadScene("Loding");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        anyText.enabled = false;
        start.SetActive(false);
        back.SetActive(false);
        aimage.enabled = false;
        bimage.enabled = false;
        cimage.enabled = false;
        agameObject.SetActive(false);
        bgameObject.SetActive(false);
        cgameObject.SetActive(false);
        switch (toolTip)
        {
            case "a":
                aimage.enabled = true;              
                agameObject.SetActive(true);
                break;
            case "b":
                bimage.enabled = true;               
                bgameObject.SetActive(true);
                break;
            case "c":
                cimage.enabled = true;            
                cgameObject.SetActive(true);
                break;
            case "s":
                start.SetActive(true);            
                break;
            default:
                back.SetActive(true);
                break;
        }

        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                anyText.enabled = false;
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                anyText.enabled = true;
                if (progressBar.fillAmount == 1.0f && OVRInput.Get(OVRInput.RawButton.Any))
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}