using UnityEngine;
using TMPro;
using PolyAndCode.UI;

public class ItemVisualizer : MonoBehaviour, ICell
{
    public TextMeshProUGUI id;
    public TextMeshProUGUI first_name;
    public TextMeshProUGUI last_name;
    public TextMeshProUGUI email;
    public TextMeshProUGUI gender;
    public TextMeshProUGUI ip_address;

    private Item _itemInfo;
    private int _cellIndex;

    public void ConfigureCell(Item itemInfo, int cellIndex)
    {
        _cellIndex = cellIndex;
        _itemInfo = itemInfo;

        id.text = itemInfo.id;
        first_name.text = itemInfo.first_name;
        last_name.text = itemInfo.last_name;
        email.text = itemInfo.email;
        gender.text = itemInfo.gender;
        ip_address.text = itemInfo.ip_address;
    }
}