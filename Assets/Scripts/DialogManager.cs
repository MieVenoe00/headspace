using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public GameObject[] tekstSider;
    public string nextScene; // navnet på scenen der skal åbnes
    private int currentIndex = 0;

    void Start()
    {
        VisKunNuværende();
    }

    void VisKunNuværende()
    {
        for (int i = 0; i < tekstSider.Length; i++)
        {
            tekstSider[i].SetActive(i == currentIndex);
        }
    }

    public void NæsteSide()
    {
        currentIndex++;

        if (currentIndex >= tekstSider.Length)
        {
            SceneManager.LoadScene(nextScene);
            return;
        }

        VisKunNuværende();
    }
}