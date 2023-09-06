using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Card : MonoBehaviour
{

    List<KeyCode> keys = new List<KeyCode>();
    Queue<KeyCode> testingKeys = new Queue<KeyCode>();
    [SerializeField] PictoBinding bind;

    [SerializeField] int debugRandomAmount = 6;

    [Button]
    void DebugRandom()
    {
        keys.Clear();
        List<KeyBinding> randomList = bind.GetRandomList(debugRandomAmount);
        foreach (KeyBinding item in randomList)
        {
            keys.Add(item.keyCode);
        }
    }

    [Button]
    public void Init()
    {
        testingKeys.Clear();
        foreach (KeyCode item in keys)
        {
            testingKeys.Enqueue(item);
        }
    }

    [Button]
    public void Begin()
    {
        StartCoroutine(WaitForKey());
    }

    private void Start()
    {
        Init();
        Begin();
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
            foreach (KeyCode item in keys)
            {
                testingKeys.Enqueue(item);
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

        Debug.Log("Win");
    }
}
