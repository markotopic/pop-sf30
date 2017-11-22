using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SF_30_2016.Util
{
    public class GenericSerializer
    {
        public static void Serialize<T>(string fileName, ObservableCollection<T> objToSerialize) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));
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

        public static ObservableCollection<T> DeSerialize<T>(string fileName) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));
                using (var sw = new StreamReader($@"../../Data/{fileName}"))
                {
                    return (ObservableCollection<T>)serializer.Deserialize(sw);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        
    }
}
