# Plans: the backlog

Future, not-yet-started features, one file each, unordered. `/stackfoundry:plan-feature` creates one from
[`_template.md`](_template.md); `/stackfoundry:implement-plan` builds one and retires it into
`../specifications/`; `/stackfoundry:retire-plan` reconciles one built outside that flow;
`/stackfoundry:backlog` lists what is open.

## Categories

Line 3 of every plan and spec is `**Category:** <word>`, one of:

- `api`: new or changed endpoints, services and credential types
- `robots`: Robot models under `src/Transloadit/Models/Robots/`
- `client`: the request pipeline, serialization, signing and the public API surface
- `platform`: target frameworks, dependencies, CI, packaging and releases

## Deferred upgrades

[`deferred-upgrades.md`](deferred-upgrades.md) holds majors that were declined or blocked, with the check that
unblocks each.
