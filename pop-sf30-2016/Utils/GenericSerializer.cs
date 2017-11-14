using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SF_30_2016.Util
{
    public class GenericSerializer
    {
        public static void Serialize<T>(string fileName, List<T> objToSerialize) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sw = new StreamWriter($@"../../Data/{ fileName}"))
                {
                    serializer.Serialize(sw, objToSerialize);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<T> DeSerialize<T>(string fileName) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var sw = new StreamReader($@"../../Data/{fileName}"))
                {
                    return (List<T>)serializer.Deserialize(sw);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        
    }
}
