using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Состояние "голодный". В этом состоянии игрок пытается найти яблоко, чтобы его
/// съесть. Если же яблока нет, то обратно переходим в состояние "ожидание".
/// </summary>
public class HungryState : PlayerBaseState
{
    private Transform _applePosition; ///< Позиция яблока, котороые игрок выбрал съесть
    private Player _player;
    private NavMeshAgent _agent; ///< Используем этот компонент, чтобы задать целевую точку

    public override void Handle()
    {
        // Указываем игроку, чтобы он дошел до яблока
        this._agent.SetDestination(this._applePosition.position);
    }

    public override void OnEnter()
    {
        // Ищем яблоко
        GameObject apple = GameObject.FindWithTag("Apple");
        
        // Если яблоко не нашли - возвращаемся в состояние "ожидание"
        if(apple == null) {
            this._context.SetState(new IdleState());
            return;
        }

        this._applePosition = apple.GetComponent<Transform>();
        this._player = this._context.gameObject.GetComponent<Player>();
        this._agent = this._context.gameObject.GetComponent<NavMeshAgent>();
    }

    public override void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Apple")
        {
            Object.Destroy(other.gameObject);
            this._player.Eat();
            this._context.SetState(new IdleState());
        }
    }
}
