using ChenKH.Tools;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureViewer
{
    public partial class Frm_Setting : Form
    {
        /// <summary>
        /// 桌面刷新
        /// </summary>
        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify(HChangeNotifyEventID wEventId, HChangeNotifyFlags uFlags, IntPtr dwItem1, IntPtr dwItem2);
        #region public enum HChangeNotifyFlags
        [Flags]
        public enum HChangeNotifyFlags
        {
            SHCNF_DWORD = 0x0003,
            SHCNF_IDLIST = 0x0000,
            SHCNF_PATHA = 0x0001,
            SHCNF_PATHW = 0x0005,
            SHCNF_PRINTERA = 0x0002,
            SHCNF_PRINTERW = 0x0006,
            SHCNF_FLUSH = 0x1000,
            SHCNF_FLUSHNOWAIT = 0x2000
        }
        #endregion//enum HChangeNotifyFlags
        #region enum HChangeNotifyEventID
        [Flags]
        public enum HChangeNotifyEventID
        {
            SHCNE_ALLEVENTS = 0x7FFFFFFF,

            SHCNE_ASSOCCHANGED = 0x08000000,

            SHCNE_ATTRIBUTES = 0x00000800,

            SHCNE_CREATE = 0x00000002,

            SHCNE_DELETE = 0x00000004,

            SHCNE_DRIVEADD = 0x00000100,

            SHCNE_DRIVEADDGUI = 0x00010000,

            SHCNE_DRIVEREMOVED = 0x00000080,

            SHCNE_EXTENDED_EVENT = 0x04000000,

            SHCNE_FREESPACE = 0x00040000,

            SHCNE_MEDIAINSERTED = 0x00000020,

            SHCNE_MEDIAREMOVED = 0x00000040,

            SHCNE_MKDIR = 0x00000008,

            SHCNE_NETSHARE = 0x00000200,

            SHCNE_NETUNSHARE = 0x00000400,

            SHCNE_RENAMEFOLDER = 0x00020000,

            SHCNE_RENAMEITEM = 0x00000001,

            SHCNE_RMDIR = 0x00000010,

            SHCNE_SERVERDISCONNECT = 0x00004000,

            SHCNE_UPDATEDIR = 0x00001000,

            SHCNE_UPDATEIMAGE = 0x00008000,
        }
        #endregion


        public Frm_Setting()
        {
            InitializeComponent();
        }

        private void Frm_Setting_Load(object sender, EventArgs e)
        {
            InitData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            chkAutoClearTemp.Checked = Define.isClearTemp;
            txtPath.Text = Define.tempPath;
            InitSkinFile();

            RegistryKey keyGIF = Registry.ClassesRoot.OpenSubKey(".gif", true);
            if (keyGIF != null && keyGIF.GetValue("").ToString() == "PictureViewer.gif")
                chkGIF.Checked = true;
            keyGIF.Close();

            RegistryKey keyBMP = Registry.ClassesRoot.OpenSubKey(".bmp", true);
            if (keyBMP != null && keyBMP.GetValue("").ToString() == "PictureViewer.bmp")
                chkBMP.Checked = true;
            keyBMP.Close();

            RegistryKey keyJPG = Registry.ClassesRoot.OpenSubKey(".jpg", true);
            if (keyJPG != null && keyJPG.GetValue("").ToString() == "PictureViewer.jpg")
                chkJPG.Checked = true;
            keyJPG.Close();

            RegistryKey keyPNG = Registry.ClassesRoot.OpenSubKey(".png", true);
            if (keyPNG != null && keyPNG.GetValue("").ToString() == "PictureViewer.png")
                chkGIF.Checked = true;
            keyPNG.Close();
        }


        #region 皮肤设置

        /// <summary>
        /// 初始化皮肤文件
        /// </summary>
        private void InitSkinFile()
        {
            if (!Directory.Exists(Application.StartupPath + "\\Skin"))
                return;
            string[] s = Directory.GetFiles(Application.StartupPath + "\\Skin");
            foreach (string str in s)
            {
                if (str.ToLower().EndsWith(".ssk"))
                {
                    try
                    {
                        int index = dgvSkin.Rows.Add();
                        dgvSkin.Rows[index].Cells["DGV_Path"].Value = str;
                        int start = str.LastIndexOf('\\');
                        int end = str.LastIndexOf('.');
                        dgvSkin.Rows[index].Cells["DGV_Name"].Value = str.Substring(start + 1, end - start - 1);
                    }
                    catch { }
                }
            }
            dgvSkin_CellClick(null, null);
        }

        private void dgvSkin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSkin.SelectedRows.Count == 0)
                return;
            string file = dgvSkin.SelectedRows[0].Cells["DGV_Name"].Value.ToString();
            string path = Application.StartupPath + "\\Skin\\" + file + ".gif";
            if (File.Exists(path))
            {
                Image img = Image.FromFile(path);
                picBox.Image = img;
            }
            else
            {
                MessageBox.Show("该皮肤没有预览图", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnClearSkin_Click(object sender, EventArgs e)
        {
            if (SkinHelper.ClearSkin())
                MessageBox.Show("清除皮肤成功，如果界面没更新，请重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("清除皮肤失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSettingSkin_Click(object sender, EventArgs e)
        {
            if (dgvSkin.SelectedRows.Count == 0)
            {
                MessageBox.Show("请在左边选择要使用的皮肤", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string path = dgvSkin.SelectedRows[0].Cells["DGV_Path"].Value.ToString();
            if (SkinHelper.SetSkin(path))
                MessageBox.Show("皮肤设置成功，如果界面没更新，请重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("皮肤设置失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region 临时文件设置

        private void btnSetTempPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Application.StartupPath;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Define.tempPath = fbd.SelectedPath;
                txtPath.Text = Define.tempPath;
            }
        }

        private void chkAutoClearTemp_Click(object sender, EventArgs e)
        {
            Define.isClearTemp = chkAutoClearTemp.Checked;
            if (Define.isClearTemp)
                ConfigHelper.SetValue(Define.CONFIG_SETTING, Define.CONFIG_IS_CLEAR_TEMP, "true");
            else
                ConfigHelper.SetValue(Define.CONFIG_SETTING, Define.CONFIG_IS_CLEAR_TEMP, "false");
        }
        #endregion

        #region 文件关联
        private void btnAssociatedFileType_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkGIF.Checked)
                    AssociatedFileType("gif");
                else
                    CancelAssociatedFileType("gif");
                if (chkBMP.Checked)
                    AssociatedFileType("bmp");
                else
                    CancelAssociatedFileType("bmp");
                if (chkJPG.Checked)
                    AssociatedFileType("jpg");
                else
                    CancelAssociatedFileType("jpg");
                if (chkPNG.Checked)
                    AssociatedFileType("png");
                else
                    CancelAssociatedFileType("png");
                MessageBox.Show("关联成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                if (MessageBox.Show("格式关联失败，可能需要管理员权限，是否以管理员运行该程序", "错误", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    RunAsAdministrator();
            }
        }

        /// <summary>
        /// 以管理员权限运行
        /// </summary>
        private void RunAsAdministrator()
        {
            System.Diagnostics.ProcessStartInfo start = new System.Diagnostics.ProcessStartInfo();
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            start.WorkingDirectory = System.Windows.Forms.Application.StartupPath;
            start.Verb = "runas";
            start.FileName = System.Windows.Forms.Application.ExecutablePath;
            System.Diagnostics.Process.Start(start);
            Application.Exit();
        }

        /// <summary>
        /// 格式关联
        /// </summary>
        /// <param name="suffix"></param>
        private void AssociatedFileType(string suffix)
        {
            //描述
            RegistryKey progID = Registry.ClassesRoot.CreateSubKey("PictureViewer." + suffix);
            progID.SetValue("", "图片查看器", RegistryValueKind.String);
            //文件显示的图标
            RegistryKey defaultIcon = progID.CreateSubKey("DefaultIcon");
            defaultIcon.SetValue("", System.Windows.Forms.Application.StartupPath + "\\Ico\\" + suffix + ".ico");
            defaultIcon.Close();
            //指定文件动作
            RegistryKey shell = progID.CreateSubKey("shell");
            //open 动作
            RegistryKey open = shell.CreateSubKey("open");
            RegistryKey command = open.CreateSubKey("command");
            command.SetValue("", "\"" + Application.ExecutablePath + "\" \"%1\"", RegistryValueKind.String);
            command.Close();
            open.Close();
            shell.Close();
            //格式关联
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("." + suffix, true);
            if (key == null)
                key = Registry.ClassesRoot.CreateSubKey("." + suffix);
            key.SetValue("", "PictureViewer." + suffix);
            key.SetValue("Content Type", "application/" + suffix);
            key.Close();
            //通知系统，文件关联已经是作用，不然可能要等到系统重启才看到效果
            SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// 取消格式关联
        /// </summary>
        /// <param name="suffix"></param>
        private void CancelAssociatedFileType(string suffix)
        {            
            //格式关联
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("." + suffix, true);
            if (key == null)
                key = Registry.ClassesRoot.CreateSubKey("." + suffix);
            if (key.GetValue("").ToString() == "PictureViewer." + suffix)
            {
                key.SetValue("", "");
                key.SetValue("Content Type", "");
            }
            key.Close();
            //通知系统，文件关联已经是作用，不然可能要等到系统重启才看到效果
            SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED, HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
        }
        #endregion

    }
}
