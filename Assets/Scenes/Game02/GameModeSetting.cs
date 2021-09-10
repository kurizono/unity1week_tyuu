using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSetting : MonoBehaviour
{
    int medicine;
    int syringe;

    // Start is called before the first frame update
    void Awake()
    {
        medicine = Game01Controller.medicineInfo[0];
        syringe = Game01Controller.medicineInfo[1];
    }


}
