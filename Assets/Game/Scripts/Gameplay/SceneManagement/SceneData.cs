using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "Scriptable Objects/Scene Data", order = 1)]
public class SceneData : ScriptableObject
{

    [field: SerializeField]
    public string Setup { get; private set; }
    [field: SerializeField]
    public string MainMenu { get; private set; }
    [field: SerializeField]
    public string Game { get; private set; }
    [field: SerializeField]
    public string Endless { get; private set; }
    [field: SerializeField]
    public string GameOver { get; private set; }
}
