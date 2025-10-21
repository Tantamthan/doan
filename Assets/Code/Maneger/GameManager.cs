using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement; // <-- Thêm thư viện này

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string SelectedCharacter;
    public Texture2D SelectedCharacterTexture;
    public static List<GameObject> Enemy = new List<GameObject>();
    public static List<GameObject> Coin = new List<GameObject>();
    public WeaponData SelectedWeapon;

    // --- CÁC HÀM CŨ CỦA BẠN ---
    public static void addToList<T>(List<T> list, T obj)
    {
        list.Add(obj);
    }
    public static void addEnemy(GameObject enemy)
    {
        Enemy.Add(enemy);
    }
    public static void delEnemy(GameObject enemy)
    {
        Enemy.Remove(enemy);
    }
    public static void addCoin(GameObject enemy)
    {
        Coin.Add(enemy);
    }
    public static void delCoin(GameObject enemy)
    {
        Coin.Remove(enemy);
    }
    public static void removeFormList<T>(List<T> list, T obj)
    {
        list.Remove(obj);
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // không bị phá khi load scene mới
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // --- PHẦN SỬA LỖI ĐƯỢC THÊM VÀO ---

    // Hàm này được gọi khi đối tượng được kích hoạt
    void OnEnable()
    {
        // Đăng ký hàm OnSceneLoaded để lắng nghe sự kiện khi một scene được tải xong
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Hàm này được gọi khi đối tượng bị vô hiệu hóa
    void OnDisable()
    {
        // Hủy đăng ký để tránh lỗi rò rỉ bộ nhớ
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Hàm này sẽ được gọi tự động mỗi khi tải scene xong
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Xóa sạch tất cả các tham chiếu cũ trong danh sách static
        Enemy.Clear();
        Coin.Clear();
        Debug.Log("GameManager: Đã xóa sạch danh sách Enemy và Coin cho màn chơi mới.");
    }
}