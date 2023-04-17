using UnityEngine;


/// <summary>
/// Базовый класс всех состояний игрока. На основе него
/// будут строиться все конкретные состояния (Idle, Sleep, Hungry)
/// </summary>
public abstract class PlayerBaseState
{
    protected PlayerContext _context; ///< каждое состояние имеет доступ к контексту, в котором оно находится

    /// <summary>
    /// Установка контекста, в котором находится состояние
    /// </summary>
    /// <param name="context"> контекст, в котором находится состояние </param>
    /// P.S. можно сделать и через setter, особой роли не играет
    public void SetContext(PlayerContext context)
    {
        this._context = context;
    }

    public abstract void Handle(); ///< Здесь содержится логика при входе в состояние
    public abstract void OnEnter(); ///< Здесь содержится логика, срабатывающая при обновлении кадра
    public abstract void OnCollisionEnter(Collision other); ///< Здесь содержится логика при столкновении с чем-то
}
