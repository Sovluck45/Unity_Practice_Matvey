using UnityEngine;
using System.Collections.Generic;
using System;

[System.Serializable]
public class PTS_DataPacket
{
    public string PlayerName;
    public Vector3 Position;
    public float RotationY;
    public int Score;
    public int Health;
    public long Timestamp;

    public PTS_DataPacket()
    {
        Timestamp = DateTime.Now.Ticks;
    }
}

public class PTS_DataManager : MonoBehaviour
{
    [Header("Настройки игрока")]
    public string CurrentUsername = "Player";

    [Header("Полученные пакеты")]
    public List<PTS_DataPacket> ReceivedPackets = new List<PTS_DataPacket>();

    /// <summary>
    /// Десериализация JSON в PTS_DataPacket
    /// </summary>
    private PTS_DataPacket DeserializePacket(string jsonData)
    {
        if (string.IsNullOrEmpty(jsonData))
            return null;

        try
        {
            // Простой способ через JsonUtility (рекомендуется в Unity)
            PTS_DataPacket packet = JsonUtility.FromJson<PTS_DataPacket>(jsonData);
            return packet;
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"[PTS] Ошибка десериализации пакета: {ex.Message}\nJSON: {jsonData}");
            return null;
        }
    }

    // Обработка входящего пакета
    public PTS_DataPacket ProcessIncomingPacket(string jsonData)
    {
        PTS_DataPacket packet = DeserializePacket(jsonData);

        if (packet != null)
        {
            ReceivedPackets.Add(packet);
            Debug.Log($"[PTS] Получен пакет от {packet.PlayerName}");
            Debug.Log($"[PTS] Позиция: ({packet.Position.x:F2}, {packet.Position.y:F2}, {packet.Position.z:F2})");
            Debug.Log($"[PTS] Здоровье: {packet.Health}, Счёт: {packet.Score}");
        }

        return packet;
    }

    // Создание исходящего пакета
    public string CreateOutgoingPacket(Vector3 pos, int sc, int hp)
    {
        PTS_DataPacket packet = new PTS_DataPacket
        {
            PlayerName = CurrentUsername,
            Position = pos,
            RotationY = UnityEngine.Random.Range(0f, 360f),   // ← Исправлено
            Score = sc,
            Health = hp
        };

        string jsonString = JsonUtility.ToJson(packet);

        Debug.Log($"[PTS] Пакет создан для отправки");
        return jsonString;
    }

    public void SendPacket(string packetData, PTPIConnection connection)
    {
        if (connection != null)
        {
            connection.SendData(packetData);
        }
    }

    public void CleanOldPackets(int maxCount = 100)
    {
        while (ReceivedPackets.Count > maxCount)
        {
            ReceivedPackets.RemoveAt(0);
        }
    }
}