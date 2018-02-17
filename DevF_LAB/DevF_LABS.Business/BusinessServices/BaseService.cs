using DevF_LABS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Business.BusinessServices
{
    public class BaseService
    {
        protected readonly IUnitOfWork uow;
        public BaseService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        //Exception handling
        protected T ExecuteWithExceptionHandledOperation<T>(Func<T> func, string errorText = null) where T : class
        {
            try
            {
                var result = func.Invoke();

                return result;
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(errorText))
                    errorText = "Yapılan işlem sırasında hata oluştu.";
                Type type = typeof(T);//aynı tip oluşturulur.
                ConstructorInfo magicConstructor = type.GetConstructor(Type.EmptyTypes);//constructure oluşturulur.
                object magicClassObject = magicConstructor.Invoke(new object[] { });//sınıf oluşturulur.
                MethodInfo methodInfo = type.GetMethod("Fail");//oluşturulan sınıfın Fail metodu bulunur.
                methodInfo.Invoke(magicClassObject, new object[] { 500, ex.HelpLink == "CustomException" ? ex.Message : errorText });//ilgili metodu gelen parametrelerle çağırırız.

                return magicClassObject as T;
            }
        }
    }
}
