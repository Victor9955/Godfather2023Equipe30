using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Linq;

public class CardSpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> forms;
    [SerializeField] Transform posForm;

    GameObject current = null;
    int last = -1;

    public static CardSpawner instance;

    private void Start()
    {
        if (instance == null)
            instance = this;
    }

    [Button]
    public void SpawnCard()
    {
        current = Instantiate(forms[GetRandom()], posForm);
        Card card = current.GetComponent<Card>();
        card.Init();

        CardSpawnerManager.instance.TimePassed = GameManager.Instance.CardScoreBonusTime;
    }

    [Button]
    int GetRandom()
    {
        if(forms.Count > 1)
        {
            int result = last;
            while (result == last)
            {
                result = Random.Range(0, forms.Count); ;
            }
            last = result;
        }
        else
        {
            last = 0;
        }
        //Debug.Log(last);
        return last;
    }
}
