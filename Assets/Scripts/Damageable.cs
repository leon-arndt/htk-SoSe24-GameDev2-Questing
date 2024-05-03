using UnityEngine;

public interface IDamageable
{
    public void Damage(float amount);
    public CharacterType GetCharacterType();
}

public enum CharacterType
{
    Enemy,
    Player,
    Neutral,
}

public class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] private CharacterType characterType;
    [SerializeField] private float health = 100f;
    
    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public CharacterType GetCharacterType()
    {
        return characterType;
    }
}