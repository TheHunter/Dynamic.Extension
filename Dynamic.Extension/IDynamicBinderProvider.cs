using System.Dynamic;

namespace Dynamic.Extension
{
    /// <summary>
    /// Rappresents a dynamic object which is able to extend own behavior adding / removing new members at runtime.
    /// </summary>
    interface IDynamicBinderProvider
        : IDynamicMetaObjectProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        object this[string propertyName] { get; set; }
    }
}
