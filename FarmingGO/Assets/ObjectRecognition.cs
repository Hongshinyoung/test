//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Vuforia;

//public class ObjectRecognition : MonoBehaviour, ITrackableEventHandler
//{
//    private TrackableBehaviour trackableBehaviour;

//    void Start()
//    {
//        trackableBehaviour = GetComponent<TrackableBehaviour>();

//        if (trackableBehaviour)
//        {
//            trackableBehaviour.RegisterTrackableEventHandler(this);
//        }
//    }

//    public void OnTrackableStateChanged(
//        TrackableBehaviour.Status previousStatus,
//        TrackableBehaviour.Status newStatus)
//    {
//        if (newStatus == TrackableBehaviour.Status.DETECTED ||
//            newStatus == TrackableBehaviour.Status.TRACKED ||
//            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
//        {
//            // �繰�� �νĵǾ��� ���� ó�� �۾��� ���⿡ �߰��մϴ�.
//            Debug.Log("Object detected or tracked!");
//        }
//        else
//        {
//            // �繰�� �νĵ��� �ʾ��� ���� ó�� �۾��� ���⿡ �߰��մϴ�.
//            Debug.Log("Object lost!");
//        }
//    }
//}