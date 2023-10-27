using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Arrow : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private Vector3 throwPosition;
    private Vector3 targetPosition;

    [SerializeField]
    GameObject audio_prefab;
    private GameObject audio_inst;

    [SerializeField]
    GameObject audio_prefab2;
    private GameObject audio_inst2;

    [SerializeField]
    GameObject efect_prefab;
    private GameObject efect_inst;


    [SerializeField]
    GameObject spart_prefab;
    private GameObject spart_inst;

    private void Start()
    {

        grabInteractable = GetComponent<XRGrabInteractable>();

        rb = GetComponent<Rigidbody>();

       
        grabInteractable.onSelectExited.AddListener(OnSelectExit);
    }


    private void OnSelectExit(XRBaseInteractor interactor)
    {
        rb.AddForce(transform.up * 2f, ForceMode.Impulse);
        throwPosition = transform.position;

        audio_inst2 = Instantiate(audio_prefab2);
        audio_inst2.transform.position = this.transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "balon")
        {
            targetPosition = collision.transform.position;

            audio_inst = Instantiate(audio_prefab);
            audio_inst.transform.position = this.transform.position;


            spart_inst = Instantiate(spart_prefab);
            spart_inst.transform.position = transform.position;
            spart_inst.transform.rotation = transform.rotation;

            efect_inst = Instantiate(efect_prefab);
            efect_inst.transform.position = collision.collider.transform.position;
            Destroy(collision.collider.transform.gameObject);

            GameObject player = GameObject.Find("Player");
            Player control = player.GetComponent<Player>();
            control.IncreaseScore(throwPosition, targetPosition);
        }
    }
}