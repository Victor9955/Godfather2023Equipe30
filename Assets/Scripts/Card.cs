using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Card : MonoBehaviour
{

    [SerializeField] List<KeyCode> keys = new List<KeyCode>();
    Queue<KeyCode> testingKeys = new Queue<KeyCode>();

    public void Init()
    {
        testingKeys.Clear();
        foreach (KeyCode item in keys)
        {
            testingKeys.Enqueue(item);
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
