using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsControl.Interfaces
{
    interface IServerInfo
    {
        string ServerId
        { get; }

        Dictionary<string, string> GetDebugData();
    }
}
