using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    [SerializeField, ReadOnly] private DriveManager driveManager;

    private bool isDriveAcitve;


    private void Start()
    {
        driveManager.DriveActive += DriveActive;
        driveManager.DriveDeactive += DriveDeactive;
    }

    void Update()
    {
        if (isDriveAcitve)
            return;

        transform.position = cameraPosition.position;
    }
    private void DriveActive()
    {

        isDriveAcitve = true;
        transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.Linear);
        transform.DOLocalRotate(Vector3.zero, 0.5f).OnComplete(() =>
        {
            gameObject.SetActive(false);
        }).SetEase(Ease.Linear);
    }

    private void DriveDeactive()
    {
        transform.parent = null;
        gameObject.SetActive(true);
        transform.DOLocalMove(cameraPosition.position, 0.5f).SetEase(Ease.Linear);
        transform.DORotate(cameraPosition.eulerAngles, 0.5f).OnComplete(() =>
        {
            isDriveAcitve = false;
        }).SetEase(Ease.Linear);

    }

    // For Optimization

    private void OnValidate()
    {
        SetRef();
    }

    private void SetRef()
    {
        driveManager = DriveManager.Instance;
    }


}
