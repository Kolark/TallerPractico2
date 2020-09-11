using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBot : User
{
    public override void SetCommand(Icommand command)
    {
        base.SetCommand(command);
        StartCoroutine(waitandExecute());
        Debug.Log("Turno del bot");
    }
    IEnumerator waitandExecute ()
    {
        yield return new WaitForSeconds(0.5f);
        base.ExecuteComand(0);
        Debug.Log("el bot ejecuto su comando");
    }
    
}
