public interface IPlayerStats
{
    float Hp { get; }
    float Defence { get; }
    float Attack { get; }
    float ExpRate { get; }
}

public interface IPlayerAttack
{
    void Attack();
}

public interface IPlayerAudio
{
    void PlaySound();
}
