using UnityEngine;


/// <summary>
/// Класс, представляющий игрока. Хранит все данные,
/// касающие игрока
/// </summary>
public class Player : MonoBehaviour
{
    [Header("Player state")]
    [SerializeField] private float _sleepiness = 0.0f; ///< Сонливость (0 - не хочет спать, 1 - очень хочет спать)
    [SerializeField] private float _hungry = 0.0f; ///< Голод (0 - полностью сытый, 1 - очень голодный)

    public float Sleepiness { get { return _sleepiness; } } ///< Геттер для получения сытости игрока
    public float Hungry { get { return _hungry; } } ///< Геттер для получения уровня голода игрока

    public void Sleep()
    {
        this._sleepiness -= 0.04f;
        this._sleepiness = Mathf.Max(this._sleepiness, 0.0f); // в случае, если сонливость отрицательная, ставим 0
    }

    public void Eat()
    {
        this._hungry -= 0.4f;
        this._hungry = Mathf.Max(this._hungry, 0.0f); // в случае, если голод отрицательный, ставим 0
    }

    public void FixedUpdate()
    {
        this._sleepiness += 0.005f;
        this._hungry += 0.002f;

        this._sleepiness = Mathf.Min(this._sleepiness, 1.0f); // если сонливость > 1, возвращаем обратно к 1
        this._hungry = Mathf.Min(this._hungry, 1.0f); // если голод > 1, возвращаем обратно к 1
    }
}
