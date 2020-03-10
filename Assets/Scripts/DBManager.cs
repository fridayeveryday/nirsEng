using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;

public class DBManager : MonoBehaviour
{
    private SqliteConnection con2db;
    private string path2db; //путь
    public string dbName;
    private SqliteCommand cmd2db;
    private SqliteDataReader dbReader;

    private static DBManager instance;

    private DBManager()
    {

    }

    public static DBManager getInstance()
    {
        if (!instance)
            instance = new DBManager();
        return instance;
    }


    private void connect()
    {
        try
        {
            if (Application.platform is RuntimePlatform.Android)
            {
                path2db = Application.persistentDataPath + "/" + dbName;
                if (!File.Exists(path2db))
                {
                    WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + dbName);
                    while (!loadDB.isDone) { }
                    File.WriteAllBytes(path2db, loadDB.bytes);
                }
            }
            else
                path2db = Application.dataPath + "/" + dbName;
            con2db = new SqliteConnection("URI=file:" + path2db);
            con2db.Open();
            //if (con2db.State.Equals("open"))// == connectionstate.open
            //{

            //}
        }
        catch(Exception exeption)
        {
            Debug.Log(exeption.ToString());
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
