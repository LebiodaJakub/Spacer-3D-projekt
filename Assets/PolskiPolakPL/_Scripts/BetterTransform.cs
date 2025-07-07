using System.Collections.Generic;
using UnityEngine;

public class BetterTransform : Transform
{
    readonly Transform outer;
    public int ChildIndex { get; private set; } = 0;

    public BetterTransform(Transform transform)
    {
        this.outer = transform;
    }

    public Transform GetNextChild()
    {
        ChildIndex++;
        ChildIndex %= outer.childCount;
        Transform child = outer.GetChild(ChildIndex);
        return child;
    }

    public Transform GetPreviousChild()
    {
        ChildIndex--;
        if (ChildIndex < 0)
            ChildIndex = outer.childCount-1;

        return outer.GetChild(ChildIndex);
    }

    public List<Transform> GetChildrenExcept(int index)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in outer)
        {
            if(child!=outer.GetChild(index))
                children.Add(child);
        }
        return children;
    }

    public Transform GetLastChild()
    {
        return outer.GetChild(outer.childCount-1);
    }

}
