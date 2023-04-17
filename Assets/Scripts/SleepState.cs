using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Состояние "сонный". В этом состоянии игрок идет до кровати и спит,
/// пока сонливость не пропадет
/// </summary>
public class SleepState : PlayerBaseState
{
    private Player _player;
    private Transform _playerPosition;
    private Transform _bedPosition;
    private NavMeshAgent _agent;

    /// <summary>
    /// Определяет, дошел ли игрок до кровати
    /// </summary>
    private bool IsNearBed()
    {
        // Находим расстояние от кровати до игрока
        float distance = Vector3.Distance(this._bedPosition.position, this._playerPosition.position);
        
        // Узнаем, находится ли игрок на довольно близком расстоянии от кровати
        return distance < 1.0f;
    }

    public override void Handle()
    {
        this._agent.SetDestination(this._bedPosition.position);

        // Если игрок достаточно поспал - возвращаемся в состояние "ожидание"
        if(this._player.Sleepiness < 0.1f)
            this._context.SetState(new IdleState());

        // Если игрок рядом с кроватью - спим
        if(IsNearBed())
            this._player.Sleep();
    }

    public override void OnEnter()
    {
        this._player = this._context.gameObject.GetComponent<Player>();
        this._bedPosition = GameObject.FindWithTag("Bed").GetComponent<Transform>();
        this._playerPosition = this._context.gameObject.GetComponent<Transform>();
        this._agent = this._context.gameObject.GetComponent<NavMeshAgent>();
    }

    public override void OnCollisionEnter(Collision other)
    {}
}
