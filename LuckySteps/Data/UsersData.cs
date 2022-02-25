using LuckySteps.interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckySteps.Data
{
    internal class UsersData
    {
        private string _path { get; set; }
        public List<IUser> _users { get; set; }
        public UsersData()
        {
            _path ="Data\\"+ DateTime.Today.ToString();
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
                _users = new List<IUser>();
            }
        }
        public void AddUser(IUser user)
        {
            _users.Add(user);
            SaveUser(_users);
        }
        public void SaveUser(List<IUser> user)
        {
            string item = JsonConvert.SerializeObject(user);
            using (FileStream file = new FileStream(_path,FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite))
            {
                byte[] lenght = BitConverter.GetBytes(item.Length);
                file.Write(lenght, 0, lenght.Length);
                byte[] list = Encoding.UTF8.GetBytes(item);
                file.Write(list, 0, list.Length);
            }
        }
        public List<IUser> Read()
        {
            string data;
            using (FileStream file = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                byte[] sizeobjects = new byte[4];
                file.Read(sizeobjects, 0, sizeobjects.Length);
                int size = BitConverter.ToInt32(sizeobjects, 0);
                byte[] list = new byte[size];
                file.Read(list, 0, list.Length);
                data = Encoding.UTF8.GetString(list);
            }
            List<IUser> item = JsonConvert.DeserializeObject<List<IUser>>(data);
            if (item == null)
            {
                return new List<IUser>(0);
            }
            return item;
        }
    }
}
