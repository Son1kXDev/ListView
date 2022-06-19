using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVisible : MonoBehaviour
{
    [SerializeField] private GameObject _content;

    private void OnBecameVisible()
    {
        print("visible");
        _content.SetActive(true);
    }

    private void OnBecameInvisible()
    {
        print("unvisible");
        _content.SetActive(false);
    }
}