using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceIcon : MonoBehaviour
{

    public enum ResourceType
    {
        food,
        wood,
        leatherbone,
        mead,
        tools,
        ore,
        knowledge,
        valuables,
        legendary       // Idea: This resource could grant the user a one-use card with magical properties
    }

    // Note: the coins should have additional logic to display a converted label:
    // COP for "copper"     1 COP
    // SV for "silver"      10 COP      == 1 SV 
    // G for "gold"         100 COP     == 10 SV    == 1 G
    // PLAT for "Platnum"   10000 COP   == 1000 SV  == 100 G

    public ResourceType Type;




    void Start()
    {
        
    }

    void Update()
    {
        
    }



}
