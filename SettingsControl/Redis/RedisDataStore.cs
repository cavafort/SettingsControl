using SettingsControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsControl.Redis
{
    class RedisDataStore:IDataStore,IDisposable
    {
        public RedisDataStore(string address)
        {
            new redispoolde
        }

        public void Set(Dictionary<string, string> data)
        {
            throw new NotImplementedException();
        }

        public void SendSignal<T>(string path, T data)
        {
            throw new NotImplementedException();
        }

        public void SubscribeSignal(string path)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
