namespace AlfredoMB.MVC
{
    public interface ISerializedModel<T>
    {
        T ToModel();
    }
}