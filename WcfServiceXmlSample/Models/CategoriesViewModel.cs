using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WcfServiceXmlSample.Models
{

    [DataContract]
    public class CategoriesViewModel
    {
        
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

}