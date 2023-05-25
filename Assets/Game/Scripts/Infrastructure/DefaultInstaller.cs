using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class DefaultInstaller : MonoInstaller
{
    [SerializeField] private SceneData _sceneData;

    public override void InstallBindings()
    {
        
    }

    public override void Start()
    {
        base.Start();
        SceneManager.LoadScene(_sceneData.MainMenu, LoadSceneMode.Single);
    }
}