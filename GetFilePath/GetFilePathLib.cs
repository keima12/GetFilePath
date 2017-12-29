using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace GetFilePath
{
    /// <summary>
    /// ファイルパスの変換処理
    /// </summary>
    public class GetFilePathLib
    {
        /// <summary>
        /// <value>dataは変換結果を保存する。 </value>
        /// </summary>
        private List<string> data;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GetFilePathLib()
        {
            data = new List<string>();
        }

        /// <summary>
        /// 引数で指定したドライブレターがネットワークドライブであるか判定する
        /// <param name="driveletter">ドライブレター</param>
        /// <returns>
        /// trueはネットワークドライブ
        /// falseはシステムドライブ
        /// </returns>
        /// </summary>
        private bool checkNetWorkDrive(string driveletter)
        {
            System.IO.DriveInfo drive = new System.IO.DriveInfo(driveletter);

            if (drive.DriveType == System.IO.DriveType.Network)
                return true;
            else
                return false;
        }
   
        /// <summary>
        /// 引数で指定したドライブレターをuncパスに変換する 
        /// </summary>
        /// <param name="drive_letter">ドライブレター</param>
        /// <returns>uncパス</returns>
        private string getUncPath(string drive_letter)
        { 

            ManagementObjectSearcher oms = new ManagementObjectSearcher();
            ManagementObjectCollection omc;
            string sMsgStr = "";

            
            oms.Query.QueryString = String.Format(
                "Select * From Win32_LogicalDisk Where DeviceID='{0}:' and DriveType = 4", drive_letter);
            omc = oms.Get();

            foreach(var i in omc)
            {
                sMsgStr = i["ProviderName"].ToString();
            }
            
            return sMsgStr;
          
        }
        /// <summary>
        /// ファイルパスがuncパスか、ドライブレター付きのパスか判定する
        /// </summary>
        /// <param name="file_path"></param>
        /// <returns>
        /// trueはuncパス
        /// falseはドライブレター付きパス
        /// </returns>
        private bool checkUncPath(string file_path)
        {
            if(System.Text.RegularExpressions.Regex.IsMatch(file_path, @"^\\\\"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //ファイル名からパスに変換する
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file_names"></param>
        /// <returns>
        /// ファイルパス今まで入力されたファイルパス
        /// </returns>
        public List<string> getPaths(string[] file_names)
        {
            
            var paths = file_names.Select((string file_name) => {
                string r;
                string driveletter = file_name[0].ToString();

                if(checkUncPath(file_name))
                {
                    return System.String.Format("<{0}>",  file_name);
                }

                if (checkNetWorkDrive(driveletter)) 
                {
                    r = getUncPath(driveletter) + file_name.Substring(2);
                }
                else
                {
                    r = file_name;
                }
                r = System.String.Format("<{0}>", r);
                return r;
            });

            foreach(var i in paths)
            {
                if (!data.Contains(i))
                    data.Add(i);
            }
               
            return data ;
        }

    }
}
