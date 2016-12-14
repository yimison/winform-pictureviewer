using PictureViewer;
using Sunisoft.IrisSkin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChenKH.Tools
{
    class SkinHelper
    {
        private static readonly SkinEngine skin = new SkinEngine();
        /// <summary>
        /// 设置皮肤
        /// </summary>
        /// <param name="filePath"></param>
        public static bool SetSkin(string filePath)
        {
            if (filePath.Length == 0)
                return ClearSkin();
            if (!File.Exists(filePath))
                return false;
            try
            {
                skin.SkinFile = filePath;
                skin.Active = true;
                skin.SkinAllForm = true;
                skin.BuiltIn = true;
                ConfigHelper.SetValue(Define.CONFIG_SETTING, Define.CONFIG_SKIN_PATH, filePath);
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
        /// <summary>
        /// 取消皮肤
        /// </summary>
        public static bool ClearSkin()
        {
            try
            {
                skin.SkinFile = "";
                skin.Active = false;
                skin.SkinAllForm = false;
                skin.BuiltIn = false;
                ConfigHelper.SetValue(Define.CONFIG_SETTING, Define.CONFIG_SKIN_PATH, "");
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex);
                return false;
            }
        }
    }
}
