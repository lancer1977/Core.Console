# Core.Console portfolio roadmap

## Snapshot
- 90-day evidence: 8 commits, 30 files changed
- Last signal: `c14beb5`
- Top modified areas: `docs`, `test`, `samples`, `src`
- Stack: .NET
- Docs folder: yes
- Roadmap folder: no
- Features docs: yes
- Tests indexed: yes

## Implemented now (V1 baseline)
- Core console behavior and setup are documented in `coreconsole.md` and docs/README.
- Core capabilities are tracked in `core-capabilities.md` and project-structure docs.
- Samples and shutdown behavior improvements are already implemented (`SampleHost`, graceful shutdown).

## Gaps and opportunities
- `test` and `samples` surfaces are not yet normalized to explicit ownership.
- Feature changes lack explicit release gates for console startup and shutdown behavior.
- Docs show configuration settings but not always tied to concrete runtime verification.

## V1 (stability)
- [ ] Add startup/shutdown smoke scripts for console host and sample host paths.
- [ ] Add compile/test gating for `src` + `test` changes in one release checklist.
- [ ] Add failure case docs for missing config and wiring mismatches.
- [ ] Create explicit release notes around console configuration keys.

## V2 (confidence)
- [ ] Expand test suite coverage for critical startup/config scenarios.
- [ ] Add sample verification matrix by runtime/target environment.
- [ ] Standardize docs for setup and release instructions in docs/features files.
- [ ] Add deprecation and compatibility notes for public console API changes.

## V10 (scale)
- [ ] Introduce reusable template for console utility repositories in the org.
- [ ] Add long-range governance for sample and test project evolution.
- [ ] Add compatibility matrix for command-line behavior and runtime arguments.
- [ ] Define maintenance ownership and update cadence in roadmap metadata.

## Roadmap checklist
- [ ] All source changes link to a test and a docs update.
- [ ] Release candidate includes clean sample run verification.
- [ ] Breaking behavior changes get explicit migration guidance.
