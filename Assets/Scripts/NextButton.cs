using UnityEngine;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public string nextScene;

    void OnMouseDown()
    {
        if (AgeSelector.Instance.HarValgt())
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.Log("Vælg en aldersgruppe først");
        }
    }
}