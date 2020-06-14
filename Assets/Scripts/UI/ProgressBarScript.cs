using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBarScript : MonoBehaviour
{
    public int minimum;
    public int maximum;
    public int current;
    public Image bar;

    void Start()
    {
        minimum = 0;
    }

    /*void Update()
    {
        GetCurrentFill();
    }*/

    private void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        bar.fillAmount = fillAmount;
    }

    public void Setup(int minimum, int maximum)
    {
        if (minimum < 0 || maximum <= 0)
            return;

        this.minimum = minimum;
        this.maximum = maximum;

        this.current = minimum;
        this.GetCurrentFill();
    }

    public void Setup(int newMaximum)
    {
        if (newMaximum < this.minimum)
            return;

        this.minimum = this.maximum;
        this.maximum = newMaximum;

        this.current = this.minimum;
        this.GetCurrentFill();
    }

    public void AddProgress(int amount)
    {
        if (amount <= 0)
            return;

        this.current += amount;
        this.GetCurrentFill();
    }

    public void Upgrade(int curr, int max)
    {
        this.current = curr;
        this.maximum = max;
        this.GetCurrentFill();
    }
}
