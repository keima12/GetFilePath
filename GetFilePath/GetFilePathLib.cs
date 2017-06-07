using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;


namespace GetFilePath
{
    public class GetFilePathLib
    {
        private List<string> data;
        public GetFilePathLib()
        {
            data = new List<string>();
        }
        // 引数で指定したドライブレターがネットワークドライブであるか
        // 判定する
        private bool checkNetWorkDrive(string driveletter)
        {
            System.IO.DriveInfo drive = new System.IO.DriveInfo(driveletter);

            if (drive.DriveType == System.IO.DriveType.Network)
                return true;
            else
                return false;
        }
        // 引数で指定したドライブレターをuncパスに変換する
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
        private bool checkUncPaht(string file_path)
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
        public List<string> getPaths(string[] file_names)
        {
            
            var paths = file_names.Select((string file_name) => {
                string r;
                string driveletter = file_name[0].ToString();

                if(checkUncPaht(file_name))
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
