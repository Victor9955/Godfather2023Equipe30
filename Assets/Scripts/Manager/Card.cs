using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using static UnityEngine.InputManagerEntry;

public class Card : MonoBehaviour
{
    public List<Key> keys;
    Queue<KeyCode> testingKeys = new Queue<KeyCode>();
    [SerializeField] PictoBinding bind;
    
    public void Init()
    {
        List<KeyBinding> random = bind.bindings.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < keys.Count; i++)
        {
            keys[i].key = random[i];
        }

        foreach (var item in keys)
        {
            item.Init();
        }

        testingKeys.Clear();
        foreach (Key item in keys)
        {
            testingKeys.Enqueue(item.key.keyCode);
        }
    }

    public void Begin()
    {
        StartCoroutine(WaitForKey());
    }

    void TestKey()
    {
        if (Input.GetKeyDown(testingKeys.Peek()))
        {
            foreach (var item in keys)
            {
                if (item.key.keyCode == testingKeys.Peek())
                {
                    item.Show();
                }
            }
            testingKeys.Dequeue();
            
            Debug.Log("Good");
        }
        else
        {
            testingKeys.Clear();
            foreach (Key item in keys)
            {
                testingKeys.Enqueue(item.key.keyCode);
                item.Hide();
            }
            Debug.Log("Retry");
        }
    }

    IEnumerator WaitForKey()
    {
        while (testingKeys.Count > 0)
        {
            if (Input.anyKeyDown)
            {
                TestKey();
            }
            yield return null;
        }

        Debug.Log("WinCard");
    }
}
