using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RockPaperScissorsGame.App.Domain
{
    public class Database<T> where T : BaseEntity
    {
        private string _folderPath;
        private string _filePath;
        private int _id;

        public Database()
        {
            _id = 0;
            _folderPath = @"..\..\..\Db";
            _filePath = _folderPath + @$"\{typeof(T).Name}.json";
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
                WriteData(new List<T>());
            }
        }
        public T FindPlayer(string playerName)
        {
            List<T> entitiesDb = ReadData();
            T existingPlayer = entitiesDb.FirstOrDefault(x => x.PlayerName == playerName);
            return existingPlayer;
        }
        public void InsertNewPlayer(T newPlayer)
        {
            List<T> entitiesDb = ReadData();
            T existingPlayer = entitiesDb.FirstOrDefault(x => x.PlayerName != newPlayer.PlayerName);
            //if (existingPlayer == null)
            //{
            _id = entitiesDb.Count;
            newPlayer.Id = _id++;
            entitiesDb.Add(newPlayer);
            //}
            WriteData(entitiesDb);
        }
        public void UpdateComputer(T player)
        {
            List<T> entitiesDb = ReadData();
            T existingPlayer = entitiesDb.FirstOrDefault(x => x.PlayerName == player.PlayerName);
            entitiesDb.Remove(existingPlayer);
            entitiesDb.Add(player);
            WriteData(entitiesDb);
        }
        public void AddPlayer(T newPlayer)
        {
            List<T> entitiesDb = ReadData();
            T existingPlayer = entitiesDb.FirstOrDefault(x => x.PlayerName == newPlayer.PlayerName);
            //if (existingPlayer != null)
            //{
            entitiesDb.Add(newPlayer);
            //}
            WriteData(entitiesDb);
        }
        public void UpdatePlayer(T updatedPlayer)
        {
            List<T> entitiesDb = ReadData();
            T existingPlayer = entitiesDb.FirstOrDefault(x => x.PlayerName == updatedPlayer.PlayerName);
            if (existingPlayer != null)
            {
                entitiesDb.Remove(existingPlayer);
                entitiesDb.Add(updatedPlayer);
            }
            WriteData(entitiesDb);
        }

        private void WriteData(List<T> EntitiesDb)
        {
            using (StreamWriter streamWriter = new StreamWriter(_filePath))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(EntitiesDb));
            }
        }
        private List<T> ReadData()
        {
            using (StreamReader streamReader = new StreamReader(_filePath))
            {
                return JsonConvert.DeserializeObject<List<T>>(streamReader.ReadToEnd());
            }
        }
    }
}
