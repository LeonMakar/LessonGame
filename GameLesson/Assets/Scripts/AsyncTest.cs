using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncTest : MonoBehaviour
{
    [SerializeField] private List<Transform> _transform;
    [SerializeField] private GameObject _finishText;


    public async void BeginTest()
    {
        //_finishText.SetActive(false);

        //await RotateTarget(_transform[0], 2);

        //var tasks = new Task[_transform.Count];
        //for (var i=0; i <_transform.Count; i++)
        //{
        //    //StartCoroutine(RotateTarget(t, 2));
        //    tasks[i] = RotateTarget(_transform[i], 2);
        //}


        //await Task.WhenAll(tasks);
        //_finishText.SetActive(true);

        var randomnumber = await GetRandomNumber();
        print(randomnumber);

    }

    //private IEnumerator RotateTarget(Transform target, float duration)
    //{
    //    var endTime = Time.time + duration;
    //    while (Time.time < endTime)
    //    {
    //        target.Rotate(new Vector3(1, 1) * Time.deltaTime * 100);
    //        yield return null;
    //    }
    //}

    private async Task RotateTarget(Transform target, float duration)
    {
        var endTime = Time.time + duration;
        while (Time.time < endTime)
        {
            target.Rotate(new Vector3(1, 1) * Time.deltaTime * 100);
            await Task.Yield();
        }

    }

    private async Task<int> GetRandomNumber()
    {
        var random = UnityEngine.Random.Range(1000, 3000);
        await Task.Delay(random);
        return random;
    }
}
