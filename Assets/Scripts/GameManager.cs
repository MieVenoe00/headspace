using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string aldersgruppe;
    public Vector3 kikosSidstePosition;
    public bool harGemtPosition = false;

    public int antalQuestsGennemført = 0;

    public bool harSetSampleIntro = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SætAldersgruppe(string gruppe)
    {
        aldersgruppe = gruppe;
        Debug.Log("Aldersgruppe valgt: " + aldersgruppe);
    }

    public void GemKikosPosition(Vector3 position)
    {
        kikosSidstePosition = position;
        harGemtPosition = true;
    }

    public void TilføjGennemførtQuest()
    {
        antalQuestsGennemført++;
        Debug.Log("Antal gennemførte quests: " + antalQuestsGennemført);
    }
}