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
        preferences.Save();
        Debug.Log("存储Preferences数据的地址Application.persistentDataPath为:" + Application.persistentDataPath);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
