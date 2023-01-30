using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeonSeon : MonoBehaviour
{
    public ConMale[] males = new ConMale[2];
    public bool con
    {
        get { return con; }
        set 
        { 
            con = value;
            if (con) { s.current_connect++; }
            else { s.current_connect--; }
        }
    }
    public scrip s;

    public void check()
    {
        if(males[0]._rconnect && males[1]._rconnect)
        {
            con = true;
        }
    }
}
