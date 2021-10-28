# `lock` vs `Monitor`

## Preparation Recipe

- Create a C# Class Library project.
- Create a field of type `object` that will be used in the `lock` and the `Monitor` statements.
  - This is just a token that identifies the locking action.
- Create one method that uses the previously created object in a `lock` block.
  - Note: lock can be used only with reference type.
- Create a second method that uses the previously created object with the `Monitor` class in the way I initially thought `lock` is implemented.
- Create a second method that uses the previously created object with the `Monitor` class in the way `lock` is really implemented.
- Build the project in release mode.
- Decompile the assembly using ILDASM tool.
  - Highlight that the `Method1` and `Method3` are identical. Text compare using https://text-compare.com/
- Decompile the assembly using DotPeek.
  - When decompiling the "release" dll:
    - Highlight that, in the decompiled C#, DotPeek wrongfully assumes that `Method3` contains a `lock` instead of the original `try-finally`.
  - When decompiling the "debug" dll and the pdb file is present
    - Highlight that, in the decompiled C#,  we obtain the original code:
      - Local variable names are present;
      - `Method3` contains the original `try-finally`.

### Best practice discussion

After the presentation, it would be interesting to discuss about:

- Do not make public the token used as parameter for `lock`. Why?
  - Do not lock on a public instances. Why?
  - Do not lock on `this`. Why?