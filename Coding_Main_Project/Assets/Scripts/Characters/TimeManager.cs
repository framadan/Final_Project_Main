using UnityEngine;
using System.Collections;

namespace code.TimeManager
{
    public class TimeManager : MonoBehaviour
    {
        
        static TimeManager _instance = null;

        public static TimeManager instance
        {
            get
            {
                if(!_instance)
                {
                    _instance = FindObjectOfType(typeof(TimeManager)) as TimeManager;
                    if(!_instance)
                    {
                        var obj = GameObject.Find("GameManager");
                        _instance = obj.AddComponent<TimeManager>();
                    }
                }

                return _instance;
            }
        }

        void OnApplicationQuit()
        {
            _instance = null;
        }

    }
}
