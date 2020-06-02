using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler
{
    public int level { get; private set; }
    public int currentXp { get; private set; }
    public int requiredXp { get; private set; }
    private int increaseXp;

    public LevelHandler(int startingRequiredXp, int increaseAmountPerLevel)
    {
        this.level = 1;
        this.currentXp = 0;
        this.requiredXp = startingRequiredXp;
        this.increaseXp = increaseAmountPerLevel;
    }

    // prida xp
    public void AddXp(int amount)
    {
        if (amount <= 0)
            return;
        this.currentXp += amount;
        CheckForLevelUp();
    }

    // Pozrie sa ci moze level up
    void CheckForLevelUp()
    {
        if (this.currentXp < this.requiredXp)
        {
            return;
        }

        while (this.currentXp >= this.requiredXp)
        {
            this.currentXp -= this.requiredXp;
            this.requiredXp += this.increaseXp;
            this.level++;
        }

        throw new LevelUpException();
    }
}
