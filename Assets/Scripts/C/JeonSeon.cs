using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeonSeon : MonoBehaviour
{
    public ConMale[] males = new ConMale[2];
    public bool con;

    public void check()
    {
        if(males[0]._rconnect && males[1]._rconnect)
        {
            con = true;
        }
    }
}
