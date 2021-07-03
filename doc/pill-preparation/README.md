# `lock` vs `Monitor`

## Preparation Recipe

- Create a C# Class Library project.
- Create a field of type `object` that will be used in the `lock` and the `Monitor` statements.
- Create one method that uses the previously created object in a `lock` block.
- Create a second method that uses the previously created object with the `Monitor` class in the way I initially thought `lock` is implemented.
- Create a second method that uses the previously created object with the `Monitor` class in the way I `lock` is really implemented.
- Build the project in release mode.
- Decompile the assembly using ILDASM tool.