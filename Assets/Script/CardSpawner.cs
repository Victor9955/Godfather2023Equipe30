using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Linq;

public class CardSpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> forms;
    [SerializeField] Transform posForm;
    [SerializeField] ReadKey read;

    GameObject current = null;
    int last = -1;

    [Button]
    void SpawnCard()
    {
        current = Instantiate(forms[GetRandom()], posForm);
        Card card = current.GetComponent<Card>();
        card.Init();
        read.Show(card.keys);
        card.Begin();
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
