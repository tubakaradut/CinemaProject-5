using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace COMMON
{
    public class ImageUpLoad
    {

        public static string UploadImage(string imagePath, HttpPostedFileBase file)
        {
            string fileName = "";
            if (file != null)
            {
                var uniqueName = Guid.NewGuid();
                imagePath = imagePath.Replace("~", "");

                var fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();//png
                fileName = uniqueName + "." + extension;

                //png,jpg,jpeg,gif
                if (extension == "png" || extension == "jpg" || extension == "jpeg" || extension == "gif")
                {
                    try
                    {
                        var filePath = HttpContext.Current.Server.MapPath(imagePath + fileName);
                        file.SaveAs(filePath);
                        return fileName;
                    }
                    catch (Exception ex)
                    {

                        return ex.Message;
                    }
                }
                else
                {
                    return "2";
                }


            }
            else
            {
                return "0";
            }
        }
    }
}

