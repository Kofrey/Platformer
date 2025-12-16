using UnityEngine;

public interface IState
{
    public abstract void Update();

    public abstract void Exit();

    public abstract void Enter();
}
