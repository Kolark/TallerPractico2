using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : User
{

    public override void SetCommand(Icommand command)
    {
        base.SetCommand(command);
        Debug.Log("Turno del player");
    }

}
