GitHub Copilot instructions for this repository

- Purpose: guidelines for the Copilot assistant when generating or modifying code in this repo.

Formatting and style
- Comments: start with a lowercase letter and do not require a full stop at the end
- Use existing project coding style and conventions
- When referring to files, directories, types, methods or properties in prose, format their names using backticks (for example: `TransloaditClient`, `AssemblyRequest`, `src/Transloadit`)

Behavior
- Make minimal changes necessary to achieve the goal
- Avoid introducing new dependencies unless absolutely necessary
- Follow the repository's target frameworks and language versions when applicable
- When asked to update comments, do NOT ever edit code; only update comments and optionally suggest non-applied code fixes based on findings

Tests and validation
- Run the build and tests when making changes that affect compilation or behavior
- Prefer small, well-scoped commits

If you need clarification about conventions not covered here, ask for specifics before making sweeping changes.

## When editing `readme.md`

- Scope: apply only when editing the repository README (`readme.md`)
- Comments: start with a lowercase letter and do not require a full stop at the end
- Keep README prose clear and concise; prefer present tense for instructions
- Make examples runnable: include required `using` directives and state async context if snippets use `await`
- Prefer `csharp` code fences and portable paths (`Path.Combine`) in examples
- Avoid changing API behavior or adding new dependencies in README edits
 - It's acceptable to show paths with forward slashes (for example: `images/snowflake.jpg`) in README examples; using `Path.Combine` is optional and `images/snowflake.jpg` is good enough for documentation
