using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Đây là cấu trúc được sử dụng để định nghĩa một bản tin báo lỗi.
    /// Lỗi chi tiết có thể xem ở thuộc tính Message của cấu trúc này.
    /// </summary>
    [DataContract]
    public struct CustomFaultMsg
    {
        /// <summary>
        /// Thuộc tính này được sử dụng để chứa thông tin chi tiết về lỗi xảy ra.
        /// Thông tin về lỗi sẽ được gửi từ dịch vụ tới client
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }
}
