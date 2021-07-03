# `lock` vs `Monitor`

## Pill Category

Language (C#)

## Description

**Concurrent access**

When there are multiple threads that must access same resource, it is mandatory to use a synchronization mechanism, otherwise we may loos data or leave the resource in an inconsistent state.

**The `lock` statement**

The simplest synchronization mechanism provided by the C# language is the `lock` statement.

```csharp
lock (obj)
{
	// do something
}
```

But, what is under the hood of this `lock` statement? Is there something that is worth mentioning? Microsoft's documentation says that the `Monitor` class is used, under the hood, to obtain and release the lock. Is that true?

This C# Pill is targeting to answer the following question.

**Question**

- Is the `lock` statement just a syntactic sugar for the usage of `Monitor` class?

