using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsControl.Interfaces
{
    public interface IDataStore
    {
        void Set(Dictionary<string, string> data);

        void SendSignal<T>(string path, T data);

        void SubscribeSignal(string path);
    }
}
