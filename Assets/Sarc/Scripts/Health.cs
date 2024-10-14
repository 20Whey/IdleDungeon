using System;
using UnityEngine;

public class Health
{
    public event Action OnHealthSet;
    public event Action<float, GameObject> OnDamaged;
    public event Action<float> OnHealed;
    public event Action OnDie;

    [SerializeField] private bool invincible;
    private bool isDead = false;

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public bool Invincible => invincible;
    public float TrueHealAmount { get; private set; }
    public bool IsDead => isDead;

    public Health(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        OnHealthSet?.Invoke();
    }

    public void Heal(int healAmount)
    {
        float healthBefore = CurrentHealth;
        CurrentHealth += healAmount;
        CurrentHealth = (int)Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

        TrueHealAmount = CurrentHealth - healthBefore;

        if (TrueHealAmount > 0f) {
            OnHealed?.Invoke(TrueHealAmount);
        }

        isDead = false;
    }

    public void TakeDamage(float damage, GameObject damageSource)
    {
        if (Invincible) return;

        float healthBefore = CurrentHealth;
        CurrentHealth -= (int)damage;
        CurrentHealth = (int)Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

        float trueDamageAmount = healthBefore - CurrentHealth;

        if (trueDamageAmount > 0f && CurrentHealth != 0) {
            OnDamaged?.Invoke(trueDamageAmount, damageSource);
        }

        HandleDeath();
    }

    public void Kill()
    {
        CurrentHealth = 0;
        OnDamaged?.Invoke(MaxHealth, null);
        HandleDeath();
    }

    public void HandleDeath()
    {
        if (isDead)
            return;

        if (CurrentHealth <= 0) {
            isDead = true;
            OnDie?.Invoke();
        }
    }
}
