using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PloyWinDto.Dto
{
    [DataContract]
    public class Response<T>
    {
        public Response()
        {
        }

        [Display(Description = "Please Display!")]
        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string code { get; set; }

        [DataMember]
        public string message { get; set; }

        [DataMember]
        public new T payload { get; set; }

        [Display(Description = "Please Display!")]
        [DataMember]
        public bool IsSuccess { get; set; }
    }
}
