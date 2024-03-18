using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakeChildrenTransparent : MonoBehaviour
{
    public float alpha = 1.0f;

    void Awake()
    {
        Stack<GameObject> stack = new Stack<GameObject>();
        stack.Push(gameObject);

        while (stack.Count > 0)
        {
            GameObject curr = stack.Pop();

            Renderer renderer = curr.GetComponent<Renderer>();
            if (renderer)
            {
                Color color = renderer.material.color;
                color.a = alpha;
                renderer.material.color = color;
            }
            
            for (int i = 0; i < curr.transform.childCount; i++)
            {
                stack.Push(curr.transform.GetChild(i).gameObject);
            }
        }
    }
}
