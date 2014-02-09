using SettingsControl.Interfaces;
using SettingsControl.Utils.SettingsWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsControl
{
    class ServerManager
    {
        const string RestartPath = "Restart";
        const string RhythmPath = "Rhythm";

        private const int signalsInterval = 10000;

        static readonly KeyPrefixer DebugPrefixer = new KeyPrefixer("Debug");
        static readonly KeyPrefixer SettingPrefixer = new KeyPrefixer("Setting");

        private readonly IServerInfo serverInfo;
        private readonly IDataStore dataStore;
        private readonly IRestarter restarter;

        public ServerManager(IServerInfo serverInfo, IDataStore dataStore, IRestarter restarter) 
        {
            if (serverInfo == null) throw new ArgumentNullException("serverInfo");
            if (dataStore == null) throw new ArgumentNullException("dataStore");
            if (restarter == null) throw new ArgumentNullException("restarter");
            this.serverInfo = serverInfo;
            this.dataStore = dataStore;
            this.restarter = restarter;            
        }

        public void PublishDebugInfo()
        {
            var debugInfo = serverInfo.GetDebugData();
            var prepared = TransformKeys(DebugPrefixer,debugInfo);
            dataStore.Set(prepared);
        }

        public async void StartPublishPulse() {
            var path = string.Join(":", RhythmPath, serverInfo.ServerId);
            while (true)
            {
                dataStore.SendSignal(path,DateTime.Now);
                await Task.Delay(signalsInterval);
            }
            
        }

        public async void StartReceiving()
        {
            var path = string.Join(":", RhythmPath, serverInfo.ServerId);
            while (true)
            {
                dataStore.SubscribeSignal(path);
                if (false) restarter.Restart();
                await Task.Delay(signalsInterval);
            }
        }

        private void OnDataStoreMessage() { 
        }

        private Dictionary<string, string> TransformKeys(KeyPrefixer prefixer, Dictionary<string, string> data)
        {
            return data
                .ToDictionary(kvp => prefixer.GetKey(kvp.Key), kvp => kvp.Value);
        }
    }
}
