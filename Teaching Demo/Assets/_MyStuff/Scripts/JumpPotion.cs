using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class JumpPotion : Collectible
{
    public int amountToAddToJumpHeight;

    public override void GetCollected()
    {
        PlatformerCharacter2D.Instance.AddJumpForce(amountToAddToJumpHeight);
    }
}
