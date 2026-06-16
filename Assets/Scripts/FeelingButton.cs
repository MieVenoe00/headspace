using UnityEngine;
using TMPro;

public class FeelingButton : MonoBehaviour
{
    public TextMeshPro tekstFelt;
    public SpriteRenderer baggrund;
    public string kategoriNavn;

    public Sprite normalSprite;
    public Sprite valgtSprite;

    private bool erValgt = false;

    void Start()
    {
        tekstFelt.text = kategoriNavn;
        baggrund.sprite = normalSprite;
        JustérBredde();
    }

    void JustérBredde()
    {
        float tekstBredde = tekstFelt.preferredWidth;
        float padding = 0.5f;
        baggrund.size = new Vector2(tekstBredde + padding, baggrund.size.y);
    }

    void OnMouseDown()
    {
        erValgt = !erValgt;
        baggrund.sprite = erValgt ? valgtSprite : normalSprite;
        FeelingManager.Instance.SætKategori(kategoriNavn, erValgt);
    }
}