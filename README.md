[![](https://img.shields.io/nuget/v/soenneker.dictionaries.singletons.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dictionaries.singletons/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dictionaries.singletons/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dictionaries.singletons/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dictionaries.singletons.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dictionaries.singletons/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dictionaries.singletons/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dictionaries.singletons/actions/workflows/codeql.yml)

# Soenneker.Dictionaries.Singletons

Specializes singleton-key dictionary operations for string keys.

## Install

```bash
dotnet add package Soenneker.Dictionaries.Singletons
```

## What you get

- `ISingletonDictionary<TValue, T1, T2>` — Specializes singleton-key dictionary operations for string keys.
- `ISingletonDictionary<TValue, T1>` — Specializes singleton-key dictionary operations for string keys.
- `ISingletonDictionary<TValue>` — Specializes singleton-key dictionary operations for string keys.

## Practical notes

- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
