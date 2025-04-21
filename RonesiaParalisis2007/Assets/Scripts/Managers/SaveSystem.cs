using System.IO;
using UnityEngine;

public class SaveSystem
{
    private static SaveData saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public StoryManagerSaveData StoryManagerData;
    }

    public static bool SaveFileExists(int saveFileSlot)
    {
        return File.Exists(GetSaveFilePath(saveFileSlot));
    }

    public static string GetSaveFilePath(int saveFileSlot)
    {
        string fileName = "Save" + saveFileSlot.ToString();
        string filePath = Application.dataPath + "/Save/" + fileName + ".save";
        Debug.Log("GetSaveFilePath: " + filePath);
        return filePath;
    }

    public static void Save(int saveFileSlot)
    {
        HandleSaveData();

        File.WriteAllText(GetSaveFilePath(saveFileSlot), JsonUtility.ToJson(saveData));
    }

    public static void HandleSaveData()
    {
        StoryManager.Instance.Save(ref saveData.StoryManagerData);
    }
}
