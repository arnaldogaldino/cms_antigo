using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace cms.nfe
{
    public class Comunic
    {
        
        public Comunic()
        { }

        public static byte[] GetByteObject(csTeste value)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter bformatter = new BinaryFormatter();
            bformatter.Serialize(stream, value);

            return stream.ToArray();
        }

        public static csTeste GetObjectByte(byte[] value)
        {
            MemoryStream stream = new MemoryStream(value);
            BinaryFormatter bformatter = new BinaryFormatter();

            return (csTeste)bformatter.Deserialize(stream);
        }



    }
}
