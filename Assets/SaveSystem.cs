using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/jordi.radev";

    public static void SaveData(ButtonBehaviour myBehaviour)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);

        ButtonBehaviourData saveData = new ButtonBehaviourData(myBehaviour);

        formatter.Serialize(stream, saveData);
        stream.Close();
    }

    public static ButtonBehaviourData LoadData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);    //read

            ButtonBehaviourData loadData = formatter.Deserialize(stream) as ButtonBehaviourData;

            stream.Close();

            return loadData;
        }
        else {
            Debug.Log("SaveData file not found");
            return null;
        }
    }
}
