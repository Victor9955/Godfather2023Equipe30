using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomKey : MonoBehaviour
{
    [SerializeField] PictoBinding bind;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bind.bindings.ElementAt(UnityEngine.Random.Range(0, bind.bindings.Count)).sprite;
    }
}
