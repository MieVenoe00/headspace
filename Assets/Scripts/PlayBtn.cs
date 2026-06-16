using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string nextScene;
    public Sprite normalSprite;
    public Sprite activeSprite;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (normalSprite != null)
            sr.sprite = normalSprite;
    }

    void OnMouseDown()
    {
        if (!FeelingsManager.Instance.HarValgtMindstEn())
        {
            Debug.Log("Vælg mindst én følelse først!");
            return;
        }

        if (activeSprite != null)
            sr.sprite = activeSprite;

        SceneManager.LoadScene(nextScene);
    }
}