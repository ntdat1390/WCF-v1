using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1, IService2
    {
        public string GetAuthors()
        {
            string a = "Nguyễn Thế Đạt";
            string b = "Nguyễn Quang Khải";
            string c = "Xây dựng ứng dụng WS cung cấp thông tin nhà hàng, quán cà phê";
            return string.Format("Tác giả: {0}   {1}. Đề tài:  {2}", a, b, c);
        }
        public string GetAuthors2()
        {
            return string.Format("Đề tài: Xây dựng ứng dụng WS cung cấp thông tin nhà hàng, quán cà phê");
        }
    }
}
