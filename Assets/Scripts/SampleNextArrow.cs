using UnityEngine;

public class SampleNextArrow : MonoBehaviour
{
    public GameObject textbobbel;
    public GameObject text1;
    public GameObject questEksempel;

    void OnMouseDown()
    {
        textbobbel.SetActive(false);
        text1.SetActive(false);
        questEksempel.SetActive(false);
        gameObject.SetActive(false);

        if (GameManager.Instance != null)
            GameManager.Instance.harSetSampleIntro = true;
    }
}