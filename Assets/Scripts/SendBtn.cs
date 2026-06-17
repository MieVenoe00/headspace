using UnityEngine;
using System.Collections;

public class SendBtn : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite activeSprite;
    private SpriteRenderer sr;
    private BoxCollider2D col;

    [Header("Hvad der skal skiftes efter send")]
    public GameObject baggrundFør;
    public GameObject baggrundEfter;
    public GameObject tekstElement;
    public GameObject beskedPapir;

    [Header("Vises efter 3 sek delay")]
    public GameObject kikoPapir;
    public GameObject text1;
    public GameObject nextArrow;
    public float ventetid = 3f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        sr.sprite = normalSprite;

        if (kikoPapir != null) kikoPapir.SetActive(false);
        if (text1 != null) text1.SetActive(false);
        if (nextArrow != null) nextArrow.SetActive(false);
    }

    void OnMouseDown()
    {
        SendKlikket();
    }

    public void SendKlikket()
    {
        sr.sprite = activeSprite;
        sr.enabled = false;
        if (col != null) col.enabled = false;

        if (baggrundFør != null) baggrundFør.SetActive(false);
        if (baggrundEfter != null) baggrundEfter.SetActive(true);
        if (tekstElement != null) tekstElement.SetActive(false);
        if (beskedPapir != null) beskedPapir.SetActive(false);

        if (GameManager.Instance != null)
        {
            GameManager.Instance.TilføjGennemførtQuest();
        }

        StartCoroutine(VisEfterDelay());
    }

    IEnumerator VisEfterDelay()
    {
        yield return new WaitForSeconds(ventetid);

        if (kikoPapir != null) kikoPapir.SetActive(true);
        if (text1 != null) text1.SetActive(true);
        if (nextArrow != null) nextArrow.SetActive(true);
    }
}