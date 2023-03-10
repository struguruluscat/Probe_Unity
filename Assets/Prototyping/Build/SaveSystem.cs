using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";


    public static void Init()
    {
        //Test if save folder exists;
        if (!Directory.Exists(SAVE_FOLDER))
        {
            //Create folder;
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }


    public static void Save(string saveString)
    {
        File.WriteAllText(SAVE_FOLDER + "/save.txt", saveString);
    }


    public static string Load()
    {
        if (File.Exists(SAVE_FOLDER + "/save.txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "/save.txt");
            return saveString;
        }
        else 
        {
            return null;
        }
    }
}