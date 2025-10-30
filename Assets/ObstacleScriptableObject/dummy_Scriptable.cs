using UnityEngine;

[CreateAssetMenu(fileName = "SciptableObject", menuName = "Object&Obstacle")]
public class dummy_Scriptable : ScriptableObject
{
    string objectName;
    string objectTipe;
    GameObject objectPrefab;
    AudioSource objectSfx;
}
