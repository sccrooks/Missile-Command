using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "Data/Scene Data")]
public class SceneData : ScriptableObject
{
    public string Setup;
    public string MainMenu;
    public string Game;
    public string Endless;
    public string GameOver;
}
