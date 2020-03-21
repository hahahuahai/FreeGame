using FreeGame;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TestCsvReading : MonoBehaviour
{
    public TextAsset CsvFile;
    private Dialogs_CSV dialogs;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("CsvFile.ToString():" + CsvFile.ToString());
        List<Dialogs_CSV> dialogs_CSVs = CsvHelper.Csv2List<Dialogs_CSV>("E:\\_data\\selfprogram\\FreeGame\\FreeGame\\Assets\\Resources\\GameData\\Dialogs.csv");
        Debug.Log("dialogs_CSVs[0].TalkContent:" + dialogs_CSVs[0].TalkContent);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
