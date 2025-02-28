using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UINavigation : MonoBehaviour
{
    public static UINavigation instance;

    [SerializeField] GameObject[] uiObjs;

    Stack<UIView> uiStack = new Stack<UIView>();

    void Awake()
    {
        instance = this;
    }

    public void Push(string viewName)
    {
        foreach (var obj in uiObjs)
            if (obj.name == viewName)
            {
                var uiView = obj.GetComponent<UIView>();
                uiStack.Push(uiView);
                uiView.Show();
            }
    }

    public void Pop()
    {
        if (uiStack.Count == 0)
            return;

        UIView uiView = uiStack.Pop();
        uiView.Hide();
    }

    public void Clear()
    {
        while (uiStack.Count > 0)
        {
            Pop();
        }
    }
}
