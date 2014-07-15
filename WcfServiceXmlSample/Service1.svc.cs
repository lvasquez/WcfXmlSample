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
using AutoMapper;
using WcfServicesXmlSample.DO;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public async Task<CategoriesViewModel> CategoriesDeSerialize(string xmlString)
        {       
            if (xmlString == null)
            {
                throw new ArgumentNullException("categories");
            }
            try 
            {
                CategoriesViewModel categories = GenericDataContractSerializer<CategoriesViewModel>.DeserializeXml(xmlString);
                var result = Mapper.Map<CategoriesViewModel, Category>(categories);
                
                using (var context = new WCFEntities())
                {                 
                    bool categoryAvailable = context.Categories.Any(x => x.CategoryID == result.CategoryID);

                    if (categoryAvailable == false)
                    {
                        context.Categories.Add(result);
                        await context.SaveChangesAsync();
                        return categories;
                    }
                    else 
                    {
                        context.Categories.Attach(result);
                        context.Entry(result).State = EntityState.Modified;
                        await context.SaveChangesAsync();
                        return categories;               
                    }                       
                }               
           }
           catch (Exception ex)
           {
               throw new ArgumentNullException("Error to Save.", ex);
           }
        }
    }
}
