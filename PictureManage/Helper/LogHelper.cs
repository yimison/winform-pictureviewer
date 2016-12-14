using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ChenKH.Tools
{
    /// <summary>
    /// ������־������
    /// �洢�ڵ�ǰ����·���� Log Error ���ļ�������
    /// </summary>
    class LogHelper
    {
        /// <summary>
        /// ��¼������־
        /// </summary>
        /// <param name="content"></param>
        public static void WriteLog(string content)
        {
            try
            {
                string path = Application.StartupPath + "\\Log";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                StreamWriter sw = new StreamWriter(path + "\\Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " --->" + content);
                sw.Close();
            }
            catch (Exception ex)
            {
                
                WriteError(ex);
            }
        }
        /// <summary>
        /// ��¼������־
        /// </summary>
        /// <param name="content"></param>
        public static void WriteError(string content)
        {
            try
            {
                string path = Application.StartupPath + "\\Error";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                StreamWriter sw = new StreamWriter(path + "\\Error_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", true);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " --->" + content);
                sw.Close();
            }
            catch { }
        }

        /// <summary>
        /// ��¼������־�Ͷ�ջ��Ϣ
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteError(Exception ex)
        {
            WriteError(ex.Message + "\n" + ex.StackTrace);
        }
    }
}
