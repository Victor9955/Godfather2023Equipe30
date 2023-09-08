using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using System.Linq;

public class CardSpawner : MonoBehaviour
{

    [SerializeField] List<GameObject> forms;
    [SerializeField] Transform posForm;
    [SerializeField] AnimationCurve difficultyCurve;

    GameObject current = null;

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
        if (forms.Count > 1)
        {
            List<int> allWeights = new List<int>();
            foreach (var item in forms)
            {
                allWeights.Add(item.GetComponent<Card>().GetKeys().Count);
            }

            allWeights = allWeights.Distinct().ToList();

            List<int> randomList = new List<int>();

            foreach (var item in allWeights)
            {
                if ((int)(difficultyCurve.Evaluate(Time.timeSinceLevelLoad)) == item)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        randomList.Add(item);
                    }
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        randomList.Add(item);
                    }
                }
            }

            int randomInt = randomList.ElementAt(Random.Range(0, randomList.Count));
            int result = 0;

            do
            {
                result = Random.Range(0, forms.Count - 1);
            }while (forms[result].GetComponent<Card>().GetKeys().Count != randomInt);

            //Debug.Log("Card number :" + result);
            //Debug.Log("With Key amount :" + randomInt);
            return result;

        }
        else
        {
            return 0;
        }
    }
}
