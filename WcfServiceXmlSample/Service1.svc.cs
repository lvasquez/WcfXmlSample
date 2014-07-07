using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;
using WcfServiceXmlSample.Models;

namespace WcfServiceXmlSample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string Serialize()
        {
            Person person = new Person("Santa", "Clause", 0929);
            string xmlString = GenericDataContractSerializer<Person>.SerializeObject(person);
            return xmlString;
        }

        public Person DesSerialize(string xmlString)
        {
            Person dPerson = GenericDataContractSerializer<Person>.DeserializeXml(xmlString);
            return dPerson;
        }
    }
}
