using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace peCourseWork
{
    internal abstract class FileIOSerializer
    {    
        //------------------------------------------------------------serialization, save, load
        internal static void saveMk2(object saveableObj, string path)
        {                   
            var binFormatter = new BinaryFormatter();
            using (var fStream = new FileStream(path, FileMode.Create))
            {
                binFormatter.Serialize(fStream, saveableObj);
                //return true;
            }
            //return false;
        }
        internal static void saveMk2(object saveableObj, Stream fs)
        {
            var binFormatter = new BinaryFormatter();
            //using (var fStream = new FileStream(path, FileMode.Create))
            {
                binFormatter.Serialize(fs, saveableObj);
                //return true;
            }
            //return false;
        }
        //-----
        internal static void loadMk2<T>(ref T loadableObj, string path)
        {

            var binFormatter = new BinaryFormatter();
            using (var fStream = new FileStream(path, FileMode.Open))
            {
                loadableObj = (T)binFormatter.Deserialize(fStream);
               //loadableObj = binFormatter.Deserialize(fStream) as T;
            }
        }
        internal static void loadMk2<T>(ref T loadableObj, Stream fs)
        {

            var binFormatter = new BinaryFormatter();
            //using (var fStream = new FileStream(path, FileMode.Open))
            {
                loadableObj = (T)binFormatter.Deserialize(fs);
                //loadableObj = binFormatter.Deserialize(fStream) as T;
            }
        }
        //---------------------------------------------------------------------------
    }
}
