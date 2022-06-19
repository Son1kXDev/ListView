using PolyAndCode.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataVisualizer : MonoBehaviour, IRecyclableScrollRectDataSource
{
    [SerializeField] private RecyclableScrollRect _recyclableScrollRect;

    [SerializeField] private int _dataLength;

    private List<Item> _itemsList = new List<Item>();

    //[SerializeField] private RectTransform _prefab;                 //������ ������ � �������
    //[SerializeField] private RectTransform _content;                //���� ���� ����� ������� ������

    //private List<RectTransform> items_rectTransform_list = new List<RectTransform>();

    private void Awake()
    {
        _recyclableScrollRect.DataSource = this;
    }

    private void Start()
    {
        GetItems(results => InitializeItemsList(results));
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
    /// ������������� ������ �� ����� �������
    /// </summary>
    /// <param name="items">������ �����</param>
    private void InitializeItemsList(Item[] items)
    {
        foreach (var item in items)
        {
            _itemsList.Add(item);
        }
    }

    #region DATA-SOURCE

    /// <summary>
    /// ����� ��������� ������. ���������� ������ ������
    /// </summary>
    public int GetItemCount()
    {
        return _itemsList.Count;
    }

    /// <summary>
    /// ����� ��������� ������. ������ �������� ������ ��� �������������
    /// </summary>
    public void SetCell(ICell cell, int index)
    {
        //Casting to the implemented Cell
        var item = cell as ItemVisualizer;
        item.ConfigureCell(_itemsList[index], index);
    }

    #endregion DATA-SOURCE

    /*#region OLD_CODE

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
            GameObject itemObj = Instantiate(_prefab.gameObject, _content, false);
            items_rectTransform_list.Add(itemObj.GetComponent<RectTransform>());
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

    #endregion OLD_CODE*/
}