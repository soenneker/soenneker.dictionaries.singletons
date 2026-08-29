using Soenneker.Dictionaries.SingletonKeys.Abstract;

namespace Soenneker.Dictionaries.Singletons.Abstract;

public interface ISingletonDictionary<TValue> : ISingletonKeyDictionary<string, TValue>;
