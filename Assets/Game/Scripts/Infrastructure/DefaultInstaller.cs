using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class DefaultInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGameManager>().To<GameManager>().AsSingle();
    }
}