using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log("Player took damage! Current HP: " + currentHP);

        if (currentHP <= 0)
        {
            Debug.Log("Player died!");
        }
    }
}
