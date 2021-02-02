using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;
using UnityEngine;

public class JumpPotion : Collectible
{
    public override void GetCollected()
    {
        PlatformerCharacter2D.Instance.MultiplyJumpForce(4.5f);
    }
}
