# Getting Started (Developer)

<small>
    If you're looking for the plugin developer guide, <a href="systems/plugins/create.html">try here instead</a>.
</small>

There are a number of prerequisites for developing OpenPuppet.

If you are on Windows, you need the following software installed on your computer.

- **Either** Visual Studio, Visual Studio Code (and build tools), or another editor of your choice.
    - It must support **.NET 10**.
    - Visual Studio 2026 is preferred, as there are things such as build scripts
        that *may* not work correctly if you don't use it.
- Git
- Basic knowledge of C#

---

<!-- Todo: Add more detail -->

1. **Fork the repository on your GitHub account.**
2. Locally clone **your fork** onto your computer
    - Typically using `git clone https://github.com/username/repo/`
3. Open the `OpenPuppet.sln` Visual Studio solution.
4. Make your changes
5. Commit your changes
6. Push your changes
7. Open a pull request
8. Done!

## Contributing

We welcome all contributions, but please make sure you follow the contributing guidelines, and code of conduct.

We accept all sorts of contributions:

- Answering questions in discussions.
- Helping to debug issues.
- Finding vulnerabilities (**DO NOT OPEN AN ISSUE FOR THIS**, please refer to the security policy on how to submit vulnerabilities).
- Contributing code.

> [!WARNING]
> If you open a pull request that is majority-made with an LLM (Large Language Model), you may
> have your pull request closed.
>
> For things such as issues, discussions, or pull request reviews, LLMs should be avoided.
> If a maintainer asks that you stop using an LLM, and you continue, you may be blocked
> from the repository.

If you are new to the codebase, it would be a good idea to find issues marked as either
["help wanted"](https://github.com/Project-Axion/OpenPuppet/issues?q=is%3Aissue+state%3Aopen+label%3A%22help+wanted%22)
or
["good first issue"](https://github.com/Project-Axion/OpenPuppet/issues?q=is%3Aissue+state%3Aopen+label%3A%22good+first+issue%22).