using UnityEngine;


/// <summary>
/// Класс контекста игрока. Именно с ним взаимодействуют
/// состояния и берут из него данные. Контекст же, в свою
/// очередь вызывает определенные методы состояния в определенные
/// моменты времени.
/// </summary>
public class PlayerContext : MonoBehaviour
{
    private PlayerBaseState _currentState; ///< текущее состояние игрока
    private Player _player;

    /// <summary>
    /// Установить новое текущее состояние в контексте
    /// </summary>
    /// <param name="state"> новое текущее состояние </param>
    public void SetState(PlayerBaseState state)
    {
        Debug.Log($"Current state : {state.GetType().Name}");
        this._currentState = state;
        this._currentState.SetContext(this); // говорим новому состоянию, в каком контексте оно находится
        this._currentState.OnEnter(); // выполняется логика при входе в состояние
    }

    private void FixedUpdate()
    {
        this._currentState?.Handle();
        // символ "?" - проверка на null. Мы сначала проверяем,
        // есть ли состояние в переменной _currentState, и
        // если это так, вызываем метод Handle()
    }

    private void Awake()
    {
        this.SetState(new IdleState());
        this._player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision other)
    {
        this._currentState?.OnCollisionEnter(other);
        // за обработку столкновения с чем-то несет ответственность
        // само состояние, поэтому при столкновении контекст просто
        // вызывает соответствующий метод у текущего состтояния
    }
}
