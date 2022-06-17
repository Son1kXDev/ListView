using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataVisualizer : MonoBehaviour
{
    [SerializeField] private RectTransform _prefab;                 //������ ������ � �������
    [SerializeField] private RectTransform _content;                //���� ���� ����� ������� ������

    private void Start()
    {
        GetItems(results => VisualizeItems(results));
    }

    /// <summary>
    /// �������� ������� �� Json
    /// </summary>
    /// <param name="callback">������ ����� �������</param>
    private void GetItems(System.Action<Item[]> callback)
    {
        Item[] results = LoadJson.instance.items();

        callback(results);
    }

    /// <summary>
    /// ������������ ������� �� �����
    /// </summary>
    /// <param name="items"></param>
    private void VisualizeItems(Item[] items)
    {
        foreach (Transform child in _content)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in items)
        {
            GameObject itemObj = Instantiate(_prefab.gameObject);
            itemObj.transform.SetParent(_content, false);
            InitializeItem(itemObj, item);
        }
    }

    /// <summary>
    /// ���������� ������ �� ������� ������� �� �����
    /// </summary>
    /// <param name="visualItem">������ �� �����</param>
    /// <param name="dataItem">������ �� �������</param>
    private void InitializeItem(GameObject visualItem, Item dataItem)
    {
        ItemVisualizer item = visualItem.GetComponent<ItemVisualizer>();

        item.id.text = dataItem.id;
        item.first_name.text = dataItem.first_name;
        item.last_name.text = dataItem.last_name;
        item.email.text = dataItem.email;
        item.gender.text = dataItem.gender;
        item.ip_address.text = dataItem.ip_address;
    }
}