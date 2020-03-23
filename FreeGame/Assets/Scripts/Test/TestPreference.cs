using FreeGame;
using Loxodon.Framework.Prefs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPreference : MonoBehaviour
{
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        BinaryFilePreferencesFactory factory = new BinaryFilePreferencesFactory();
        Preferences.Register(factory);

        Preferences preferences = Preferences.GetGlobalPreferences();
        bool b = preferences.ContainsKey("ChinesePeople");
        Debug.Log("名为ChinesePeople的Preferences数据是否存在:" + b);
        preferences.SetString("ChinesePeople", "lilei");

        PlayerModel playerModel = new PlayerModel(this.transform, 10);
        preferences.SetInt("score", playerModel.Score);
        preferences.SetObject("position", playerModel.Position);
        preferences.SetObject("rotation", playerModel.Rotation);

        preferences.Save();
        Debug.Log("存储Preferences数据的地址Application.persistentDataPath为:" + Application.persistentDataPath);

        Debug.Log("Score为:" + preferences.GetInt("score"));
        Debug.Log("Position为:" + preferences.GetObject<Vector3>("position"));
        Debug.Log("Rotation为:" + preferences.GetObject<Vector3>("rotation"));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
