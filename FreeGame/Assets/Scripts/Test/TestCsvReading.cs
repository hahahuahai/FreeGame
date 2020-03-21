using FreeGame;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TestCsvReading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Dialogs_CSV> dialogs_CSVs = CsvHelper.Csv2List<Dialogs_CSV>(CsvNames.Dialogs);
        Debug.Log("dialogs_CSVs[0].TalkContent:" + dialogs_CSVs[0].TalkContent);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
