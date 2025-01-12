using _00_Shared;
using UnityEngine;

namespace _1_Loading
{
    public class GameConfigLoader : MonoBehaviour
    {
        public static GameConfigLoader Instance;
        public GameConfig GameConfig;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            InvokeRepeating(nameof(LoadConfig), 0f, 3f);
        }

        private void LoadConfig()
        {
            Debug.Log(nameof(LoadConfig));
            if (Instance != null && Instance.GameConfig != null) return;

            StartCoroutine(
                AtlasHelper.GetConfig(result =>
                {
                    GameConfig = result;
                    SceneNavigation.SwitchToPlayerSelection();
                })
            );
        }
    }
}