using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class CardSpawner : MonoBehaviour
{

    [SerializeField] GameObject cardPrefab;



    [Button]
    void SpawnCard()
    {
        Instantiate(cardPrefab);
        
    }

}
