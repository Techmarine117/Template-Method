using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class template 
{
   public void game()
    {
        this.player();
        this.gun();
        this.armor();

    }

    public void player()
    {
        Debug.Log("player has joined the game");
    }

    public void gun()
    {
        Debug.Log("player has equipped a mp5");
    }

    public void armor()
    {
        Debug.Log("player has equipped light armor");
    }

    public abstract void team();

   

}
