using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hahmonOhjaus : MonoBehaviour
{


    public float juoksuNopeus = 3;
    public float hiirenNopeus = 3.0f; //f ei ole pakollinen
    public float painoVoima = 10;
    public float horisontaalinenPyorinta = 0;
    public float vertikaalinenPyorinta = 0;
    public float maxKaannosAsteet = 60;

    public CursorLockMode valittuTila;

    private Vector3 liikeSuunta = Vector3.zero;

    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = valittuTila;
        Cursor.visible = (CursorLockMode.Locked != valittuTila);


    }

    // Update is called once per frame
    void Update()
    {
        horisontaalinenPyorinta += Input.GetAxis ("Mouse X") * hiirenNopeus;
        vertikaalinenPyorinta -= Input.GetAxis ("Mouse Y") * hiirenNopeus;
        //Debug.Log($"asteet{horisontaalinenPyorinta}");
        vertikaalinenPyorinta = Mathf.Clamp(vertikaalinenPyorinta, -maxKaannosAsteet, maxKaannosAsteet);

        Camera.main.transform.localRotation = Quaternion.Euler(vertikaalinenPyorinta, horisontaalinenPyorinta, 0);



    }
}
