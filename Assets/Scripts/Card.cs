using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Card : MonoBehaviour
{

    [SerializeField] List<string> keys = new List<string>();
    Queue<string> testingKeys = new Queue<string>();
    bool isKey;

    void Start()
    {
        testingKeys.Clear();
        foreach (string item in keys)
        {
            testingKeys.Enqueue(item);
        }
        StartCoroutine(WaitForKey());
    }
    
    void GetKey(string key)
    {
        Debug.Log(key);
        if (key == testingKeys.Peek())
        {
            testingKeys.Dequeue();
        }
        else
        {
            testingKeys.Clear();
            foreach (string item in keys)
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
                InputSystem.onAnyButtonPress.CallOnce(ctrl => GetKey(ctrl.name));
            }
            yield return null;
        }

        Debug.Log("Win");
    }

}
