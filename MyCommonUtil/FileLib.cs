using System;
using System.IO;

namespace MyCommonUtil
{
    public class FileLib
    {
        /// <summary>
        /// 在指定的路徑建立所有目錄和子目錄 (如果這些目錄尚不存在)。
        /// </summary>
        /// <param name="path">要建立的目錄。</param>
        /// <returns></returns>
        public static void CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
            }
            catch (IOException ex)
            {
                throw new Exception(string.Format("執行錯誤，原因：{0}", ex.Message));
            }
        }

        /// <summary>
        /// 移動指定的檔案至新的位置，提供指定新檔名的選項。
        /// </summary>
        /// <param name="sourceFileName">要移動的檔案名稱。可包含相對或絕對路徑。</param>
        /// <param name="newPath">檔案的新路徑</param>
        /// <param name="newFileName">檔案的新名稱</param>
        /// <returns></returns>
        public static void MoveFile(string sourceFileName, string newPath, string newFileName)
        {
            try
            {
                #region 將檔案移至目的資料夾
                // 目錄是否存在，不存在則建立新目錄
                if (Directory.Exists(newPath) == false)
                    CreateDirectory(newPath);

                // To move a file or folder to a new location:
                System.IO.File.Move(sourceFileName, newPath + newFileName);

                #endregion                
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                throw new Exception(string.Format("執行錯誤，原因：{0}", ex.Message));
            }
        }

        /// <summary>刪除指定的檔案。</summary>
        /// <param name="path">要刪除的檔案的名稱。不支援萬用字元。</param>
        /// <returns></returns>
        public static void DeleteFile(string path)
        {
            try
            {
                //刪除檔案
                File.Delete(path);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("執行錯誤，原因：{0}", ex.Message));
            }
        }
    }
}
