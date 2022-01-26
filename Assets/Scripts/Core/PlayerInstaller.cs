using System;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindRotetes();
        BindHealth();
    }

    private void BindRotetes()
    {
        Container.BindInstance(GetComponent<LeftRotate>())
            .AsSingle();

        Container.BindInstance(GetComponent<RightRotate>())
            .AsSingle();

        Container.BindInstance(GetComponent<BackRotate>())
            .AsSingle();

        Container.BindInstance(GetComponent<Rotator>())
            .AsSingle();
    }

    private void BindHealth()
    {
        Container.BindInstance(GetComponent<Health>())
            .AsSingle();
    }
}