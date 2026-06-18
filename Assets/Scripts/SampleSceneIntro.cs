using UnityEngine;

public class SampleSceneIntro : MonoBehaviour
{
    public GameObject textbobbel;
    public GameObject text1;
    public GameObject questEksempel;
    public GameObject nextArrow;

    void Start()
    {
        if (GameManager.Instance != null && GameManager.Instance.harSetSampleIntro)
        {
            textbobbel.SetActive(false);
            text1.SetActive(false);
            questEksempel.SetActive(false);
            nextArrow.SetActive(false);
        }
        else
        {
            textbobbel.SetActive(true);
            text1.SetActive(true);
            questEksempel.SetActive(true);
            nextArrow.SetActive(true);
        }
    }
}