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
        current = Instantiate(forms[0], posForm);
        Card card = current.GetComponent<Card>();
        card.Init();
        read.Show(card.keys);
        card.Begin();
    }


    int GetRandom()
    {
        List<int> random = new List<int>();
        for (int i = 0; i < forms.Count - 1; i++)
        {
            random.Add(i);
        }
        if(last >= 0)
        {
            random.Remove(last);
        }
        Debug.Log(random);
        last = random.ElementAt(Random.Range(0, random.Count));
        return last;
    }
}
