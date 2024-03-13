using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Splines;

public class SplineTest : MonoBehaviour
{
    [SerializeField] private SplineContainer splineContainer;
    [SerializeField] Rigidbody Rigidbody;

    [SerializeField]  private Spline currentSpline;
    void Start()
    {
        currentSpline = splineContainer.Spline;
        
    }

    // Update is called once per frame
    void Update()
    {
        var native = new NativeSpline(currentSpline);
        float distance = SplineUtility.GetNearestPoint(native, transform.position, out float3 nearest, out float t);
        transform.position = nearest;

        Vector3 forward = Vector3.Normalize(currentSpline.EvaluateTangent(t));
        Vector3 up = currentSpline.EvaluateUpVector(t);
        var remappedForward = new Vector3(0,1,0);
        var remappedUP = new Vector3(0,0,1);
        var axisRemapRotation = Quaternion.Inverse(Quaternion.LookRotation(remappedForward, remappedUP));

        transform.rotation = Quaternion.LookRotation(forward, up) * axisRemapRotation;

        Rigidbody.velocity = Rigidbody.velocity.magnitude * transform.up;
        if(Input.GetKey(KeyCode.Space))
        {
            Rigidbody.AddForce(transform.up*100);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Rigidbody.AddForce(-transform.up);
        }
    }

}
