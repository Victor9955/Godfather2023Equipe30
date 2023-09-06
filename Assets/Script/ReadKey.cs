using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadKey : MonoBehaviour
{
    [SerializeField] GameObject[] showKeys;

    public void Show(List<Key> keys)
    {
        foreach (GameObject item in showKeys)
        {
            item.SetActive(false);
        }

        for (int i = 0; i < keys.Count - 1; i++)
        {
            showKeys[i].GetComponent<SpriteRenderer>().sprite = keys[i].key.sprite;
            showKeys[i].SetActive(true);
        }
    }
}
