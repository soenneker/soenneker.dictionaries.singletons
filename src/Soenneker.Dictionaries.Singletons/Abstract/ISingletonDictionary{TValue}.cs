using Soenneker.Dictionaries.SingletonKeys.Abstract;

namespace Soenneker.Dictionaries.Singletons.Abstract;

/// <summary>
/// Specializes singleton-key dictionary operations for string keys.
/// </summary>
public interface ISingletonDictionary<TValue> : ISingletonKeyDictionary<string, TValue>;
