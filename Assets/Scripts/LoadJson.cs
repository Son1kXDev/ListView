using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class LoadJson : MonoBehaviour
{
    public static LoadJson instance;

    private string _path;               //путь до json файла

    /// <summary>
    /// Массив предметов из json
    /// </summary>
    /// <returns></returns>
    public Item[] items()
    {
        return JsonConvert.DeserializeObject<Item[]>(File.ReadAllText(_path));
    }

    private void Awake()
    {
        if (instance != null) Destroy(this);
        else instance = this;

        _path = Application.streamingAssetsPath + "/" + "test_mock_data.json";
    }
}

/// <summary>
/// Строка с данными
/// </summary>
public class Item
{
    public string id;
    public string first_name;
    public string last_name;
    public string email;
    public string gender;
    public string ip_address;
}