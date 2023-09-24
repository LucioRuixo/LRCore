namespace LRCore.Utils.IO
{
    public interface ISerializable<ConstraintType>
    {
        T Deserialize<T>(string path) where T : ConstraintType;
    }
}