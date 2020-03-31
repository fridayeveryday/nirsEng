using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;

public struct pairOfWord
{
    public string word;
    public string translate;
}
public class DBManager : MonoBehaviour
{
    List<pairOfWord> words= new List<pairOfWord>();
    //Dictionary<string, string> words = new Dictionary<string, string>();
    private SqliteConnection con2db;
    private string path2db; //путь
    private string dbName = "db.bytes";
    private SqliteCommand cmd2db;
    public SqliteDataReader dbReader;

    private static DBManager instance;



    

    private void Awake()
    {
        if (!instance)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        connect();
    }


    public static DBManager getInstance()
    {
        if (!instance)
        {
            GameObject dbManager = new GameObject("dbManager");
            instance = dbManager.AddComponent<DBManager>();
        }
        return instance;
    }


    public void connect()
    {
        try
        {
            if (Application.platform is RuntimePlatform.Android)
            {
                path2db = Application.persistentDataPath + "/" + dbName;
                if (!File.Exists(path2db))
                {
                    //UnityWebRequest loadDB = UnityWebRequest.
                    WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + dbName);
                    while (!loadDB.isDone) { }
                    File.WriteAllBytes(path2db, loadDB.bytes);
                }
            }
            else
                path2db = Application.dataPath + "/" + dbName;

            con2db = new SqliteConnection("URI=file:" + path2db);
            con2db.Open();
            //if (con2db.State == ConnectionState.Open)
            //{
            //    //Debug.Log("connected!!");
            //}
            //else
            //{
            //    //Debug.Log("pisos");
            //}
        }
        catch(Exception exeption)
        {
            //Debug.Log(exeption.ToString());
        }
      
    }
    public void disconnect()
    {
        try
        {
            con2db.Close();
        }
        catch (Exception ex) {
            //Debug.Log(ex.ToString());
        }
    }

    /// <summary>
    /// put in the database a new pair (word and translate)
    /// </summary>
    /// <param name="word"></param>
    /// <param name="translate"></param>
    /// <returns>return true or false if insert is succesful or not </returns>
    public bool insertData2DB(string word, string translate)
    {
        string com4existingNewWord = "SELECT * FROM words WHERE word = '" + word +
            "'and translate = '" + translate + "';";
        cmd2db = new SqliteCommand(com4existingNewWord, con2db);
       
        if (cmd2db.ExecuteNonQuery() == 0)
        {
            try
            {
                string insCom = "INSERT INTO words (word, translate) " +
                        "VALUES ('" + word + "', '" + translate + "');";
                cmd2db = new SqliteCommand(insCom, con2db);
                cmd2db.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                //Debug.Log(ex.ToString());
            }
           
        }
        else
        {
            //Debug.Log("yet exist");
            return false;
        }
       
    }

    [SerializeField] string command = "SELECT * FROM words;";

    /// <summary>
    /// get a pair (word and translate) from database
    /// </summary>
    /// <param name="words"> words is a list of pairs for adding in it from db </param>   
    public void executeData(List<pairOfWord> words )
    {
        
        try
        {
            cmd2db = new SqliteCommand(command, con2db);
            dbReader = cmd2db.ExecuteReader();

            string word, translate;
            pairOfWord tempPairOfWord;
            while (dbReader.Read())
            {
                word = dbReader[1].ToString();
                translate = dbReader[2].ToString();
                tempPairOfWord.word = word;
                tempPairOfWord.translate = translate;
                if(!words.Contains(tempPairOfWord))
                    words.Add(tempPairOfWord);

                //words.Values()
                //if(words.)
                //words.Add(word, translate);

                Debug.Log("get in loop");

                Debug.Log(word);
                Debug.Log(translate);
               
            }
        }
        catch(Exception ex)
        {
            //Debug.Log(ex.ToString());
        }
       
    }

    private void OnDestroy()
    {
        disconnect();
    }
  
}
