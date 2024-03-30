public abstract class Singleton<T> where T : class, new()
{
   protected static T _Instance = null;
   public static T Instance
   {
      get
      {
         if (null == _Instance)
         {
            _Instance = new T();
         }
         return _Instance;
      }
   }
   protected Singleton()
   {
      if (null != _Instance)
      {
         throw new System.Exception("this null");
         // throw new SingletonException("this null");
      }
      // Init();
   }

   public virtual void Init()
   {

   }

   public virtual void Dispose()
   {

   }
}
