using Soenneker.Dictionaries.SingletonKeys.Abstract;

namespace Soenneker.Dictionaries.Singletons.Abstract;

public interface ISingletonDictionary<TValue, T1> : ISingletonKeyDictionary<string, TValue, T1>;
