using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Состояние "ожидание". В этом состоянии игрок просто стоит и выбирает,
/// в какое состояние перейти в зависимости от его сонливости и голода
/// </summary>
public class IdleState : PlayerBaseState
{
    private Player _player; ///< Берем компонент Player, чтобы узнать показатели сонливости и голода

    public override void Handle()
    {
        // [!!!] Обратите внимание на else if. Это означает, что для игрока
        // сонливость приоритетнее голода
        if(this._player.Sleepiness > 0.7f)
            this._context.SetState(new SleepState());
        
        else if(this._player.Hungry > 0.5f)
            this._context.SetState(new HungryState());
    }

    public override void OnEnter()
    {
        this._player = this._context.gameObject.GetComponent<Player>();
    }

    public override void OnCollisionEnter(Collision other)
    {}
}
