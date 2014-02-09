using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingsControl.Utils
{
    using System;

    namespace SettingsWrapper
    {
        /// <summary>
        /// Преобразование имен настроек в ключи redis и наоборот
        /// </summary>
        internal class KeyPrefixer
        {
            private readonly string keyPrefix;

            public KeyPrefixer(string keyPrefix)
            {
                this.keyPrefix = keyPrefix ?? string.Empty;
            }

            public string GetKey(string settingName)
            {
                return string.Format("Setting.{0}.{1}", keyPrefix, settingName ?? string.Empty).ToUpper();
            }

            public string GetSettingName(string key)
            {
                if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");
                if (!key.StartsWith(keyPrefix, StringComparison.InvariantCultureIgnoreCase)) throw new ArgumentOutOfRangeException("key");
                return key.Substring(keyPrefix.Length);
            }
        }
    }

}
