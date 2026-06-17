using UnityEngine;

public class BagageBarManager : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Sprites fra tung til let bagage")]
    public Sprite[] bagageSprites; // [0] = tungest, sidste element = lettest

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        OpdaterBar();
    }

    void OpdaterBar()
    {
        int gennemført = GameManager.Instance != null ? GameManager.Instance.antalQuestsGennemført : 0;
        int index = Mathf.Clamp(gennemført, 0, bagageSprites.Length - 1);

        if (bagageSprites.Length > 0)
        {
            sr.sprite = bagageSprites[index];
        }
    }
}