using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int pipesPassed { get; set; }
    public static bool isWkeyEnabled { get; set; }
    public static float pipePeriod{ get; set; }
    public static float vitality{ get; set; }
    public static float vitalitySpeed { get; set; }

    public static String toJson()
    {
        return JsonUtility.ToJson(new SaveData());
    }

    public static void FromJson(String json)
    {
        var data = JsonUtility.FromJson<SaveData>(json);
        pipePeriod = data.pipePeriod;
        isWkeyEnabled = data.isWkeyEnabled;
        vitalitySpeed = data.vitalitySpeed;
    }
}
[Serializable]
public class SaveData
{
    public bool isWkeyEnabled;
    public float pipePeriod;
    public float vitalitySpeed;
    public SaveData()
    {
        pipePeriod = GameState.pipePeriod;
        isWkeyEnabled = GameState.isWkeyEnabled;
        vitalitySpeed = GameState.vitalitySpeed;
    }
}
/* Об'єкт-стан -- доступний для усіх скриптів "центр"
 * збереження загальної інформації щодо стану гри
 */