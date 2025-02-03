using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void Save(GameManagerSO gM)
    {
        //defino donde va a estar la ruta de guardado
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/" + "save001.txt";

        //creo un archivo en esa ruta si es que no existe
        FileStream fileStream = new FileStream(savePath, FileMode.Create);

        //crear un archivo de datos persistente
        PersitentData dataToSave = new PersitentData(gM.lifes, gM.ultimaPosicion);

        //guardo los datos
        formatter.Serialize(fileStream, dataToSave);

        //por ultimo cieero el stream de escritura
        fileStream.Close();

        
    }

    public static void Load()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savePatch = Application.persistentDataPath + "/" + "saveve001.txt";

        FileStream fileStream = new FileStream(savePatch, FileMode.Create);


    }
}
