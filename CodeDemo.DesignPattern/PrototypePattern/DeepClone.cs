using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CodeDemo.DesignPattern.PrototypePattern
{
    /// <summary>
    /// 深克隆
    /// </summary>
    public class DeepClone
    {
        /// <summary>
        /// 深克隆 通过 Stream
        /// </summary>
        /// <returns></returns>
        public DeepClone DeepCloneStream()
        {
            using Stream objStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(objStream, this);
            objStream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(objStream) as DeepClone;
        }

        /// <summary>
        /// 深克隆通过JSON
        /// </summary>
        /// <returns></returns>
        public DeepClone DeepCloneJson()
        {
            var jsonStr = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<DeepClone>(jsonStr);
        }

        
    }
}
