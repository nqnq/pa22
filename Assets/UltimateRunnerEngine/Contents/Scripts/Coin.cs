using System;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    [HideInInspector]
    public float audioPitch;

    public string color;

    public void pickUp()
    {

     
        this.transform.parent = GameGlobals.Instance.trackGenerator.trackObjectsRoot.transform;
        this.transform.position = GameGlobals.Instance.trackGenerator.rootPos;

        // Coins are deactiving in coin line controllers

        GameGlobals.Instance.achievements.increasePoints(1);
        GameGlobals.Instance.controller.doAnEffect(Controller.EffetcType.PointPickup);

        if (audioPitch > 0)
        {
            GameGlobals.Instance.audioController.playSoundPitched("PowerupCoin", audioPitch);
        }
        else
        {
            GameGlobals.Instance.audioController.playSoundPitched("PowerupCoin", 1.0f);
        }
        
        audioPitch = 0;

        if (color == "red")
        {

        }
        if (color == "yellow")
        {
            PowerupController.instance.SetGolds(1);
        }
        if (color == "blue")
        {
            PowerupController.instance.SetGolds(2);
        }
    }

}