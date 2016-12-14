using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ChenKH.Tools
{
    /// <summary>
    /// 配置文件config.ini帮助类
    /// </summary>
    class ConfigHelper
    {
        static string configPath = Application.StartupPath + "\\config.ini";

        [DllImport("kernel32")]
        private static extern void WritePrivateProfileString(string section, string key, string value, string filePath);

        [DllImport("kernel32")]
        private static extern double GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, configPath);
        }
        
        /// <summary>
        /// 取值
        /// </summary>
        /// <param name="section">节点名称</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(100);
            GetPrivateProfileString(section, key, "", temp, 100, configPath);
            return temp.ToString();
        }
    }
}
