using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void Save(int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savefile.gut";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, score);

        stream.Close();
    }

    public static int Load()
    {
        string path = Application.persistentDataPath + "/"
    }

}