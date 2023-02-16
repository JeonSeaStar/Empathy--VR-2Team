using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class JeonSeon : MonoBehaviour
{
    public ConMale[] males = new ConMale[2];
    public bool _con;
    public bool con
    {
        get { return _con; }
        set 
        {
            _con = value;

            if (con) { s.current_connect++; }
            else if(!con) { s.current_connect--; }
        }
    }
    public scrip s;
    public ObiSolver os;

    public void check()
    {
        if (males[0]._rconnect && males[1]._rconnect)
        {
            con = true;
            os.gravity = new Vector3(0, 0, 0);
        }
        else if(!males[0]._rconnect || !males[1]._rconnect)
        {
            if (con) { con = false; }
        }
    }
}
