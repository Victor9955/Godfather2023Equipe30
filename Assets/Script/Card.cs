using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
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

        for (int i = 0; i < keys.Count - 1; i++)
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
            testingKeys.Dequeue();
            Debug.Log("Good");
        }
        else
        {
            testingKeys.Clear();
            foreach (Key item in keys)
            {
                testingKeys.Enqueue(item.key.keyCode);
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
