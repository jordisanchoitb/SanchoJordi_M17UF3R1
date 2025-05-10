using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AEntity
{
    public static Player instance;

    public override void OnEnable()
    {
        base.OnEnable();
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public override void Hurt(float damage)
    {
        base.Hurt(damage);
    }
}
