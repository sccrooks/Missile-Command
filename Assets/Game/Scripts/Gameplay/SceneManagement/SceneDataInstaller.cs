using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SceneDataInstaller", menuName = "Installers/SceneDataInstaller")]
public class SceneDataInstaller : ScriptableObjectInstaller<SceneDataInstaller>
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

    public override void InstallBindings()
    {
    }
}