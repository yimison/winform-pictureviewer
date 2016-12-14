using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ChenKH.Tools
{
    /// <summary>
    /// �����ļ�config.ini������
    /// </summary>
    class ConfigHelper
    {
        static string configPath = Application.StartupPath + "\\config.ini";

        [DllImport("kernel32")]
        private static extern void WritePrivateProfileString(string section, string key, string value, string filePath);

        [DllImport("kernel32")]
        private static extern double GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// ����ֵ
        /// </summary>
        /// <param name="section">�ڵ�����</param>
        /// <param name="key">��</param>
        /// <param name="value">ֵ</param>
        public static void SetValue(string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, configPath);
        }
        
        /// <summary>
        /// ȡֵ
        /// </summary>
        /// <param name="section">�ڵ�����</param>
        /// <param name="key">��</param>
        /// <returns>ֵ</returns>
        public static string GetValue(string section, string key)
        {
            StringBuilder temp = new StringBuilder(100);
            GetPrivateProfileString(section, key, "", temp, 100, configPath);
            return temp.ToString();
        }
    }
}
